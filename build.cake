var target = Argument("target", "Test");
var configuration = Argument("configuration", "Release");

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

Task("Clean")
    .WithCriteria(c => HasArgument("rebuild"))
    .Does(() => {
        //CleanDirectory($"./src/Example/bin/{configuration}");
        
        // Delete a file.
        //DeleteFile("./file.txt");

    });

Task("Build")
    .IsDependentOn("Clean")
    .Does(() => {
        DotNetCoreBuild("./Impulse.sln", new DotNetCoreBuildSettings
        {
            Configuration = configuration,
        });
    });

Task("Test")
    .IsDependentOn("Build")
    .Does(() => {
        DotNetCoreTest("./Impulse.sln", new DotNetCoreTestSettings
        {
            Configuration = configuration,
            NoBuild = true,
        });
    });

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);