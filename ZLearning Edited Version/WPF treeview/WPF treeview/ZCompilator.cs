using Newtonsoft.Json;
using Raqamli_Avlod;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPF_treeview;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.Threading;

namespace forma_1
{
    class ZCompilator
    {
        [Obsolete]
        public string compilator(string code, string Out)
        {
            string error_List = "";
            
            CSharpCodeProvider codeProvider = new CSharpCodeProvider();
            ICodeCompiler icc = codeProvider.CreateCompiler();

            System.CodeDom.Compiler.CompilerParameters parameters = new CompilerParameters();
            parameters.GenerateExecutable = true;
            parameters.OutputAssembly = Out;
            CompilerResults results = icc.CompileAssemblyFromSource(parameters, code);
            if (results.Errors.Count > 0)
            {
                foreach (CompilerError CompErr in results.Errors)
                {
                    error_List +=
                        "Line number " + CompErr.Line +
                        ", Error Number: " + CompErr.ErrorNumber +
                        ", '" + CompErr.ErrorText + ";" +
                        Environment.NewLine + Environment.NewLine;
                }
            }
            else
            {
                //Successful Compile
                error_List = "Success!";
                //If we clicked run then launch our EXE
                Process.Start(Out);
            }
            return error_List;
        }

        #region
        int lang_key = 5, global_res = 0;
        string result = "";
        string systemPath = Functions.PublicPath;
        public Process pro = null;
        public string Compile(string code, string lang, string problem_name, string correct, string error_test, string error_comp)
        {
            try
            {
                lang = lang.ToLower();
                pro = new Process();
                ProcessStartInfo info = new ProcessStartInfo("cmd.exe");
                info.RedirectStandardInput = true;
                info.RedirectStandardOutput = true;
                info.UseShellExecute = false;
                info.CreateNoWindow = true;
                info.Verb = "runas";
                info.WorkingDirectory = systemPath;
                pro.StartInfo = info;
                //file checker
                string mavzu = problem_name.Split('-')[0], tartib = problem_name.Split('-')[1];
                var list = JsonConvert.DeserializeObject<List<getProblemClass>>(File.ReadAllText(systemPath + "Contest/" + mavzu + ".json"));
                list.RemoveAt(0);
                List<Test> testList = new List<Test>();
                testList.Add(list[int.Parse(tartib) - 1].Test1); testList.Add(list[int.Parse(tartib) - 1].Test2); testList.Add(list[int.Parse(tartib) - 1].Test3);
                pro.OutputDataReceived += data_received;

                int k = 0;
                string class_name = "";
                foreach (var dir in testList)
                {
                    pro.Start();
                    global_res = 0;
                    if (lang == "c++")
                    {
                        lang_key = 5;
                        File.WriteAllText(systemPath + "C++.cpp", code);
                        pro.StandardInput.WriteLine("g++ C++.cpp & a.exe & exit");
                    }
                    else if (lang == "python")
                    {
                        lang_key = 5;
                        File.WriteAllText(systemPath + "python.py", code);
                        pro.StandardInput.WriteLine("python python.py & exit");
                    }
                    else if (lang == "java")
                    {
                        lang_key = 5;
                        string code2 = code;
                        code2 = code2.Remove(code2.IndexOf("{"));
                        class_name = code2.Substring(code2.IndexOf("class ") + 5).Trim();
                        File.WriteAllText(systemPath + class_name + ".java", code);
                        pro.StandardInput.WriteLine("javac " + class_name + ".java & java " + class_name + " & exit");
                    }
                    pro.BeginOutputReadLine();

                    //data
                    string[] input = dir.Input.Split();
                    string output = dir.Output;
                    foreach (var inp in input)
                    {
                        pro.StandardInput.WriteLine(inp);
                    }
                    pro.WaitForExit();
                    if (result == output) k++;
                    else
                    {
                        return (k + 1).ToString() + "-test! Hatolik";
                    }
                    //delete file
                    if (lang == "c++")
                    {
                        if (File.Exists(systemPath + "C++.cpp")) File.Delete(systemPath + "C++.cpp");
                        if (File.Exists(systemPath + "a.exe")) File.Delete(systemPath + "a.exe");
                    }
                    else if (lang == "java")
                    {
                        File.Delete(systemPath + class_name + ".java");
                        File.Delete(systemPath + class_name + ".class");
                    }
                    if (lang == "python")
                    {
                        File.Delete(systemPath + "python.py");
                    }
                    pro.CancelOutputRead();
                }
                if (k == testList.Count) return correct;
                else return error_comp;
            }
            catch
            {
                return error_comp;
            }
            
        }
        private void data_received(object sender, DataReceivedEventArgs e)
        {
            global_res++;
            if (e.Data != null)
            {
                if (global_res == lang_key) result = e.Data;
            }
        }
        #endregion
    }
}
