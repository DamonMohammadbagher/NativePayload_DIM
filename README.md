# NativePayload_DIM

NativePayload_DIM Dynamic native dll Injection in Memory , Injecting Native DLL bytes to local Process

Note: `NativePayload_DIM is simple csharp code to loading Native Dll [unmanaged dll] into Managed Processes [.NET Processes] without read dll from disk [in-memory only]` , this will help you to bypass AVs and Blue team tools etc also you can convert this Csharp code to Managed Dll then you can inject this code to any process you want [Native Processes or Managed Processes] and ...

in this code i used two old C++ Codes "ShellcodeFluctuation" & "CallStackSpoofer" as Native DLL to inject them into local Managed Process in his case "NativePayload_DIM" and you can see results was good in these pictures.

Note: `C++ Codes for "ShellcodeFluctuation" & "CallStackSpoofer" was changed by me and output of projects changed to dll, Function name "run" added into source codes also these codes will download cobaltstrike "payload.bin" via web traffic so we have two change in source codes for these c++ projects` , you can find original source code in below link

C++ Original Source codes:

ShellcodeFluctuation => https://github.com/mgeeky/ShellcodeFluctuation

ThreadStackSpoofer => https://github.com/mgeeky/ThreadStackSpoofer


#### NativePayload_DIM background step-by-step

      Step1: Native dll bytes from web downloaded via bmp extension loaded into local process in-memory [ShellcodeFluctuation.dll or ThreadStackSpoofer.dll renamed to bmp extension]
      Step2: Native dll after loading in local process [Managed process] will call Funcation name "run" and this function will get payload.bin from web
      Step3: in-memory that payload.bin will run also [cobaltstrike session established]
      Step4: in-memory ShellcodeFluctuation.dll will encode payloads [Sleep-mask + delay] or in-memory with ThreadStackSpoofer.dll you will have stack spoofing with delay 



### NativePayload_DIM + loading Native Dll "ShellcodeFluctuation.dll" into local process
   ![](https://github.com/DamonMohammadbagher/NativePayload_DIM/blob/main/Pics/ShellcodeFluctuation1.png)
   
### NativePayload_DIM & Detection via ETW Memory-scanner for ShellcodeFluctuation method in-memory before encoding...
   ![](https://github.com/DamonMohammadbagher/NativePayload_DIM/blob/main/Pics/ShellcodeFluctuation2.png)
   
-------------------
### NativePayload_DIM + loading Native Dll "ThreadStackSpoofer.dll" into local process
   ![](https://github.com/DamonMohammadbagher/NativePayload_DIM/blob/main/Pics/callstackspoofer.png)
   
   
<p><a href="https://hits.seeyoufarm.com"><img src="https://hits.seeyoufarm.com/api/count/incr/badge.svg?url=https://github.com/DamonMohammadbagher/NativePayload_DIM"/></a></p>
