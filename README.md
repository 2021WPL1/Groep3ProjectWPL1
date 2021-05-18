# ProjectWPL1
repo for WPL1 - group 3

### Planning
Add an X between the brackets to check off the item.

#### Bugfixes
- [ ] Check MVVM framework - correct one?

#### Week 1
> voorzien dat via registry er keys en values voor naam, afdeling en functie kunnen opgehaald worden bij opstarten van opstellen van Request. Dit kan misschien ook voorzien worden voor controle van request en inplannen van request (dus 3 reeksen keys)

- [ ] Request form: Registry key + values for *Name*
- [ ] Request form: Registry key + values for *Department*
- [ ] Request form: Registry key + values for *Function*
- [ ] Request validation: Registry key + values for *Name*
- [ ] Request validation: Registry key + values for *Department*
- [ ] Request validation: Registry key + values for *Function*
- [ ] Request planning: Registry key + values for *Name*
- [ ] Request planning: Registry key + values for *Department*
- [ ] Request planning: Registry key + values for *Function*

#### Week 2 + Week 3
> Request gebeurt met gegevens uit registry (naam, divisie, ea)
> Bij versturen van request wordt 1x per dag (op vast tijdstip) een mail verstuurd naar keurder waarbij alle aanvragen worden vermeld.
> Goedkeuring: request openen, aanpassen (tester(s) aanduiden) en goedkeuren. Dit levert een volgnummer en een datum van goedkeuren. Er wordt een mail gestuurd naar betrokken testers. Vanaf dan loopt termijn van 5 (werk)dagen.
> Inplannen: tester opent de jobrequest en bepaalt de datum van de test(s), duidt resources aan (aanduiden als er al gebruik is van resource). Mogelijks aanduiden dat inconsistent voor de resource!
> Optioneel: overzicht van termijn van inplannen van aangevraagde tests (5 dagen overzicht van voorbije maand)


- [ ] Autofill request with registry data (name, division,....
- [ ] Send daily mail, at a fixed time, with a list of all requests (if any)
- [ ] Approval: open request (by planner)
- [ ] Approval: adapt request (add testers)
- [ ] Approval: generate serial number
- [ ] Approval: autofill approval date
- [ ] Approval: mail added testers
- [ ] Approval: add 5 day timer
- [ ] Planning: open request (by tester)
- [ ] Planning: Determine test dates
- [ ] Planning: choose resources
- [ ] Planning: Give warning if the resource in use
- [ ] Optional: overview of planning delays _(?)_


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

The Head of Testing is responsible for merging *shadowTesting* --> *shadowMain* --> *Main*

### SCRUM action points
1. Clean-up and merging during the final hour of the WPL-week
2. Shift system for back-end, front-end, testing and DB: responsibilities shift every week
3. Topics to learn by next sprint:  
   * MVVM
   * DataTemplates
   * Data and event binding
   * DAO functions
   * opening/closing windows
   * Creating and merging branches
   * Scaffolding an existing DB

### Loading the project
Create a public class Constants (not loaded due to gitignore)
Add the following variable:

    public static string CONNECTION_STRING = "Server=XXXXXXXXXXXXXXXXXXX;Database=Barco2021;Trusted_Connection=True;";
    
Replace the X's with the location of your database.

#### TODO
* Known issues
    * Weird bug where you get error un saving an existing RQ unless you open DAO bezfore running (can this be reproduced?)
* Add instructions for loading the project
* Add TODO's for WPL1 part two
        * Fix folder structure
* ... 
