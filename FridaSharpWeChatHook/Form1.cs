using Binarysharp.MemoryManagement;
using Binarysharp.MemoryManagement.Assembly.CallingConvention;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Threading;

namespace FridaSharpWeChatHook
{
    public partial class Form1 : Form
    {
        Frida.DeviceManager deviceManager;
        List<Frida.Device> Devices;
        List<Frida.Process> Processes;
        Frida.Session session;
        Frida.Script script;
        
        Process target;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void Hook()
        {
            try
            {
                Devices = new List<Frida.Device>();
                Processes = new List<Frida.Process>();
                deviceManager = new Frida.DeviceManager(Dispatcher.CurrentDispatcher);
                var devices = deviceManager.EnumerateDevices();
                var device = devices.Where(x => x.Name == "Local System").FirstOrDefault();
                if (device == null)
                {
                    return;
                }
                target = Process.GetProcesses().FirstOrDefault(k=>k.ProcessName == "WeChat");
                session = device.Attach((uint)target.Id);
                try
                {
                    var scriptText = txtScript.Text;
                    script = session.CreateScript(scriptText);
                    script.Message += new Frida.ScriptMessageHandler(script_Message);
                    script.Load();
                    txtLog.Text = "Success......";
                }
                catch (Exception ex)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
            }
        }
        private void script_Message(object sender, Frida.ScriptMessageEventArgs e)
        {
            if (sender == script)
            {
                txtLog.Text = e.Message + "\n" + txtLog.Text;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            try
            {
                script.Unload();
                script.Dispose();
                session.Detach();
                session.Dispose();
                deviceManager.Dispose();
                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnHook_Click(object sender, EventArgs e)
        {
            Hook();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            script.Dispose();
            session.Dispose();
        }

        private void btnSendTextMsg_Click(object sender, EventArgs e)
        {
            target = Process.GetProcesses().FirstOrDefault(k => k.ProcessName == "WeChat");
            using (var ms = new MemorySharp(target))
            {
                var mod = ms.Modules.RemoteModules.FirstOrDefault(k => k.Name == "WeChatWin.dll");
                var msgAddress = AllocateWxDataStruct(ms,txtMsg.Text);
                var wxIdAddress = AllocateWxDataStruct(ms,txtWxId.Text);
                var tempAddress = AllocatePtr(ms,4);
                var rt = ms.Assembly.InjectAndExecute(
                    new string[] {
                        "push 0",
                        "push 0",
                        "push 1",
                        "push 0",
                        string.Format("push 0x{0}",msgAddress.ToString("X")),
                        string.Format("mov edx, 0x{0} ",wxIdAddress.ToString("X")),
                        string.Format("mov ecx, 0x{0}",tempAddress.ToString("X")),
                        string.Format("call 0x{0}",(mod.BaseAddress.ToInt32()+ 0x55D320).ToString("X")),
                        "add esp,0x14",
                        "ret"
                    });
            }
        }

        public IntPtr AllocatePtr(MemorySharp ms, int size)
        {
            var rtPtr = ms.Memory.Allocate(4);
            ms.Write(rtPtr.BaseAddress, ms.Memory.Allocate(4).BaseAddress, false);
            return rtPtr.BaseAddress;
        }

        public IntPtr AllocateAddress(MemorySharp ms)
        {
            var rtPtr = ms.Memory.Allocate(4);
            ms.Write(rtPtr.BaseAddress, 0, false);
            return rtPtr.BaseAddress;
        }

        public IntPtr AllocateAddress(MemorySharp ms, int val)
        {
            var rtPtr = ms.Memory.Allocate(4);
            ms.Write(rtPtr.BaseAddress, val, false);
            return rtPtr.BaseAddress;
        }

        public IntPtr AllocateAddress(MemorySharp ms,string txt)
        {
            var rtPtr = ms.Memory.Allocate(txt.Length);
            ms.WriteString(rtPtr.BaseAddress, txt, Encoding.Unicode, false);
            return rtPtr.BaseAddress;
        }

        public IntPtr AllocateWxDataStruct(MemorySharp ms,string text)
        {
            var textAddr = ms.Memory.Allocate(text.Length);
            ms.WriteString(textAddr.BaseAddress, text, Encoding.Unicode, false);

            var startAddr = ms.Memory.Allocate(4);
            ms.Write(startAddr.BaseAddress, textAddr.BaseAddress, false);
            ms.Write(startAddr.BaseAddress + 4 , text.Length * 2, false);
            ms.Write(startAddr.BaseAddress + 8, text.Length * 2, false);
            return startAddr.BaseAddress;
        }

        public IntPtr AddFriendByWxidParamStruct(MemorySharp ms)
        {
            var startAddr = ms.Memory.Allocate(4);
            ms.Write(startAddr.BaseAddress, 0, false);
            ms.Write(startAddr.BaseAddress + 4, 0, false);
            ms.Write(startAddr.BaseAddress + 8, 0, false);
            ms.Write(startAddr.BaseAddress + 12, 0, false);
            ms.Write(startAddr.BaseAddress + 16, 0, false);
            ms.Write(startAddr.BaseAddress + 20, 0, false);
            return startAddr.BaseAddress;
        }

        private void btnSearchWxInfo_Click(object sender, EventArgs e)
        {
            target = Process.GetProcesses().FirstOrDefault(k => k.ProcessName == "WeChat");
            using (var ms = new MemorySharp(target))
            {
                var mod = ms.Modules.RemoteModules.FirstOrDefault(k => k.Name == "WeChatWin.dll");
                var searchTextAddress = AllocateWxDataStruct(ms, txtPhone.Text.Trim());
                var rt = ms.Assembly.InjectAndExecute(
                    new string[] {
                        string.Format("call 0x{0}",(mod.BaseAddress.ToInt32()+ 0x329C80).ToString("X")),
                        string.Format("mov ebx, 0x{0} ",searchTextAddress.ToString("X")),
                        "push ebx",
                        "mov ecx,eax",
                        string.Format("call 0x{0}",(mod.BaseAddress.ToInt32()+ 0x54AEC0).ToString("X")),
                        "ret"
                    });
            }
        }

        private void btnAddFriend_Click(object sender, EventArgs e)
        {
            target = Process.GetProcesses().FirstOrDefault(k => k.ProcessName == "WeChat");
            
            using (var ms = new MemorySharp(target))
            {
                var desc = AllocateAddress(ms, txtDesc.Text.Trim());
                var v3 = AllocateWxDataStruct(ms, txtV3.Text.Trim());
                var tempAddress = AddFriendByWxidParamStruct(ms);

                var mod = ms.Modules.RemoteModules.FirstOrDefault(k => k.Name == "WeChatWin.dll");
                var ebxParam = AllocateAddress(ms, mod.BaseAddress.ToInt32() + 0x1FBD5F4); // 0x7A3D6E48

                var addFriendByV3ParamAddr = ms.Read<int>(new IntPtr(mod.BaseAddress.ToInt32() + 0x2424518),false);
                var asm = new string[] {
                        "mov edi, 0xF",
                        "sub esp, 0x18",
                        "mov ecx, esp",
                        "mov dword [ebp-0x64], esp",
                        "mov esi, 0",
                        "mov eax, 2",
                        "mov dword [ebp-0x60], eax",
                        "mov dword [ecx], 0x0",
                        "mov dword [ecx+0x14], 0xF",
                        "mov dword [ecx+0x10], 0x0",
                        "mov byte [ecx], 0x0",
                        "sub esp, 0x18",
                        "mov byte [ebp-0x4], 0xB",
                        string.Format("mov eax, 0x{0} ",tempAddress.ToString("X")),
                        "mov ecx, esp",
                        "push eax",
                        string.Format("call 0x{0}",(mod.BaseAddress.ToInt32()+ 0x10A9C0).ToString("X")),
                        "push 0",
                        "push 0xF",
                        string.Format("mov edi, 0x{0} ",desc.ToString("X")),

                        "mov eax, edi",
                        "sub esp, 0x14",
                        "mov ecx, esp",
                        "push -1",
                        "push eax",
                        string.Format("call 0x{0}",(mod.BaseAddress.ToInt32()+ 0x7A83B0).ToString("X")), // 7A83B0
                        "push 2",
                        string.Format("mov eax, 0x{0} ",v3.ToString("X")),
                        "sub esp, 0x14",
                        "mov ecx, esp",
                        "push eax",
                        string.Format("call 0x{0}",(mod.BaseAddress.ToInt32()+ 0x7A84A0).ToString("X")),
                        string.Format("mov ecx, 0x{0}",addFriendByV3ParamAddr.ToString("X")),   
                        string.Format("mov ebx, 0x{0}",ebxParam.ToString("X")),
                        string.Format("call 0x{0}",(mod.BaseAddress.ToInt32()+ 0x496980).ToString("X")),
                        //"popfd",
                        //"popad",
                        "ret"
                    };
                var asmcode = string.Join("\n", asm);
                var rt = ms.Assembly.InjectAndExecute(asm);
            }
        }

        private void btnSendPic_Click(object sender, EventArgs e)
        {
            target = Process.GetProcesses().FirstOrDefault(k => k.ProcessName == "WeChat");
            using (var ms = new MemorySharp(target))
            {
                var mod = ms.Modules.RemoteModules.FirstOrDefault(k => k.Name == "WeChatWin.dll");

                IntPtr picAddress = IntPtr.Zero;

                var dlg = new OpenFileDialog();
                dlg.Title = "选择图片";
                dlg.Filter = "*.jpg|*jpg|*.png|*.png";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    picAddress = AllocateWxDataStruct(ms, dlg.FileName);
                }
                var wxIdAddress = AllocateWxDataStruct(ms, txtWxId.Text);
                var tempAddress = AllocatePtr(ms, 4);
                var rt = ms.Assembly.InjectAndExecute(
                    new string[] {
                        "sub esp,0x14",
                        string.Format("mov ecx, 0x{0}",(mod.BaseAddress.ToInt32()+ 0x2424250).ToString("X")),
                        string.Format("push 0x{0}",picAddress.ToString("X")),
                        string.Format("push 0x{0} ",wxIdAddress.ToString("X")),
                        string.Format("push 0x{0}",tempAddress.ToString("X")),
                        string.Format("call 0x{0}",(mod.BaseAddress.ToInt32()+ 0x55CDC0).ToString("X")),
                        "ret"
                    });
            }
        }
    }
}
