# ProjectWPL1
repo for WPL1 - group 3

### Planning
WPL1 starts again on 18/05/2021!

### GitHub Use Conventions
Code and comments will be written in english: [coding conventions](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/inside-a-program/coding-conventions)

New branches start from *shadowTesting*. Branches are named after the functionaility you're trying to implement.

Merging your branch with *shadowTesting*:
1. Commit your branch
2. If necessary, stash changes
3. Pull *shadowTesting*
4. If necessary, stash changes
5. Merge *shadowTesting* into your current branch
6. Resolve conflicts
7. Commit
8. **Does your code work?**
    * YES: stash changes if necessary, then push
    * NO: fix it, go back to 1.

### SCRUM action points
1. Clean-up and merging during the final hour of the WPL-week
2. Shift system for Back-end, front-end, testing and DB
3. Topics to learn by next sprint:  
   * MVVM
   * DataTemplates
   * Data and event binding
   * DAO functions
   * opening/closing windows
   * Creating and merging branches
   * Scaffolding an existing DB

### Known issues
TODO

### Loading the project
Create a public class Constants (not loaded due to gitignore)
Add the following variable:

    public static string CONNECTION_STRING = "Server=XXXXXXXXXXXXXXXXXXX;Database=Barco2021;Trusted_Connection=True;";
    
Replace the X's with the location of your database.
