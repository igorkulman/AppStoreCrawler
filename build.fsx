// include Fake lib
#r @"tools\FAKE\tools\FakeLib.dll"
open Fake
 
RestorePackages()

// Properties
let buildDir = @".\build\"
let testDir  = @".\test\"
let packagesDir = @".\packages"

// tools
let nunitVersion = GetPackageVersion packagesDir "NUnit.Runners"
let nunitPath = sprintf @"./packages/NUnit.Runners.%s/tools/" nunitVersion

 
// Targets
Target "Clean" (fun _ ->
    CleanDirs [buildDir; testDir]
)

Target "BuildApp" (fun _ ->
    !! @"AppStoreCrawler\*.fsproj"
      |> MSBuildRelease buildDir "Build"
      |> Log "AppBuild-Output: "
)

Target "BuildTest" (fun _ ->
   !! @"AppStoreCrawler.Tests\*.fsproj"
      |> MSBuildDebug testDir "Build"
      |> Log "TestBuild-Output: "
)

Target "Test" (fun _ ->
    !! (testDir + @"\AppStoreCrawler.Tests.dll") 
      |> NUnit (fun p ->
          {p with
             ToolPath = nunitPath;
             DisableShadowCopy = true;
             OutputFile = testDir + @"TestResults.xml" })
)

Target "Default" (fun _ ->
    trace "Build completed"
)
 
// Dependencies
"Clean"
  ==> "BuildApp"
  ==> "BuildTest"
  ==> "Test"
  ==> "Default"
 
// start build
Run "Default"