using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mainhub.Tools.WebAppGenerator.Controllers
{
    /// <summary>
    /// 
    /// TYPES:
    ///     -MVC USING NUGET PACKAGES WITH MAIN C# CODE WRITTEN
    ///     -TEMPLATES IS NORMAL MVC NO EXTRA PACKAGES INSTAL
    ///     -CMS USUAL CMS(YET TO DEFINE)
    /// 
    /// </summary>
    public class GeneratorController : Controller
    {
        public ActionResult Generate()  
        {
            return View("Generate","_Layout");
        }
        public string Create(string name, string type, string path, bool modular, bool run)
        {
            //type mvc vao incluir packages jafeitos
            string feedbackMessage = "Created succesfully";
            Process process = new Process();
            if (modular && type.ToLower() == "mvc")
            {
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.CreateNoWindow = false;
                process.StartInfo.RedirectStandardInput = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.UseShellExecute = false;
                process.Start();
                process.StandardInput.WriteLine($"cd \"{path}\"");
                process.StandardInput.WriteLine("dotnet new -i OrchardCore.ProjectTemplates::1.0.0-*");
                process.StandardInput.WriteLine($"dotnet new oc{type} -n \"{name}\"");
                process.StandardInput.WriteLine($"dotnet new ocmodulemvc -n \"{name}Module\"");
                process.StandardInput.WriteLine($"dotnet add {name} reference {name}Module");
                if (run)
                {
                    process.StandardInput.WriteLine($"dotnet run --project {type}\\{name}\\{name}.csproj");
                }
                process.StandardInput.Flush();
                process.StandardInput.Close();
            }
            else if (!modular && type.ToLower() == "mvc")
            {
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.CreateNoWindow = false;
                process.StartInfo.RedirectStandardInput = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.UseShellExecute = false;
                process.Start();
                process.StandardInput.WriteLine($"cd \"{path}\"");
                process.StandardInput.WriteLine("dotnet new -i OrchardCore.ProjectTemplates::1.0.0-*");
                process.StandardInput.WriteLine($"dotnet new oc{type} -n \"{name}\"");
                if (run)
                {
                    process.StandardInput.WriteLine($"dotnet run --project {path}\\{name}\\{name}.csproj");
                }
                //process.StandardInput.Flush();
                //process.StandardInput.Close();
            }
            else if (modular && type.ToLower() == "template")
            {
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.CreateNoWindow = false;
                process.StartInfo.RedirectStandardInput = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.UseShellExecute = false;
                process.Start();
                //VALIDATE PATH
                process.StandardInput.WriteLine($"cd \"{path}\"");
                process.StandardInput.WriteLine("dotnet new -i OrchardCore.ProjectTemplates::1.0.0-*");
                process.StandardInput.WriteLine($"dotnet new ocmvc -n \"{name}\"");
                process.StandardInput.WriteLine($"dotnet new ocmodulemvc -n \"{name}Module\"");
                process.StandardInput.WriteLine($"dotnet add \"{name}\" reference \"{name}Module\"");
                if (run)
                {
                    process.StandardInput.WriteLine($"dotnet run --project {path}\\{name}\\{name}.csproj");
                }
                process.StandardInput.Flush();
                process.StandardInput.Close();
                Console.WriteLine(process.StandardOutput.ReadToEnd());
                process.StandardOutput.Close();
            }
            else if (!modular && type.ToLower() == "template")
            {
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.CreateNoWindow = false;
                process.StartInfo.RedirectStandardInput = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.UseShellExecute = false;
                process.Start();
                process.StandardInput.WriteLine($"cd \"{path}\"");
                process.StandardInput.WriteLine("dotnet new -i OrchardCore.ProjectTemplates::1.0.0-*");
                process.StandardInput.WriteLine($"dotnet new ocmvc -n \"{name}\"");
                if (run)
                {
                    process.StandardInput.WriteLine($"dotnet run --project {path}\\{name}\\{name}.csproj");
                }
                process.StandardInput.Flush();
                process.StandardInput.Close();
            }
            else if(modular && type.ToLower() == "cms")
            {
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.CreateNoWindow = false;
                process.StartInfo.RedirectStandardInput = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.UseShellExecute = false;
                process.Start();
                process.StandardInput.WriteLine($"cd \"{path}\"");
                process.StandardInput.WriteLine("dotnet new -i OrchardCore.ProjectTemplates::1.0.0-*");
                process.StandardInput.WriteLine($"dotnet new oc{type} -n \"{name}\"");
                process.StandardInput.WriteLine($"dotnet new ocmodulecms -n \"{name}Module\"");
                process.StandardInput.WriteLine($"dotnet add {name} reference {name}Module");
                if (run)
                {
                    process.StandardInput.WriteLine($"dotnet run --project {path}\\{name}\\{name}.csproj");
                }
                process.StandardInput.Flush();
                process.StandardInput.Close();
            }
            else if (!modular && type.ToLower() == "cms")
            {
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.CreateNoWindow = false ;
                process.StartInfo.RedirectStandardInput = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.UseShellExecute = false;
                process.Start();
                //Get path to install the webapp
                process.StandardInput.WriteLine($"cd \"{path}\"");
                process.StandardInput.WriteLine("dotnet new -i OrchardCore.ProjectTemplates::1.0.0-*");
                process.StandardInput.WriteLine($"dotnet new oc{type} -n \"{name}\"");
                if (run)
                {
                    process.StandardInput.WriteLine($"dotnet run --project {path}\\{name}\\{name}.csproj");
                }
                process.StandardInput.Flush();
                process.StandardInput.Close();
            }
            return feedbackMessage;
        }
    }
}