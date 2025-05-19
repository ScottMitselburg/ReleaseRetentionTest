### QUESTIONS
How is the data actually coming in, is it getting sent as JSON files, or is it going to come in as correct models ?

What do you do with no releases ?

what do you do with releases, that havent being deployed ?

### ASSUMPTIONS
The instructions mention "What shape the data might be in" - Going to make the assumption that, that is the correct shape and build it based off that. I am making that assumption based on if i was working at DevOps Deploy part of doing this work would be confirming the shape of the data that is coming in. The information is also coming from their own systems so they would be able to control the shape and know what it is.

Returning the releases that should be kept. I think returning the releases as the models they are is a good call. I would assume that the method / api for deleting them would use the same model. going on the theory that this is being built inside the same repo as that logic. If not would just make sure that the models match or that the models them self are in a area multiple places can reference them.

The data might not always come in correct, so i want to add data validation to each model - if it doesnt fit the model correctly throw an error, but is there any data that can actually be missing. Sometimes you never know how but data can be wrong or missing. So if there is missing data do you want to stop the whole process or just keep going. I think stopping the process is the right call. working with broken or incorrect data can get messy.

In the supplied JSON files there is a null Version on a Release. But a release can exist but not be deployed yet. So will make the assumption that a Version doesnt get updated until that release is deployed.

There is also a release with a projectId that doesnt exist in the Projects. So will make the assumption that a project can be deleted but that doesnt remove the releases relating to it. which wont break anything as it wont show up in the project / environment combonations. 

If there is no Deployments, then a release hasnt had any recent activity, customers only care about releases that have recently been deployed. So it should return a empty list of releases to keep. to be inline with "keep `n` **releases** that have most recently been deployed".

If there is no Releases, i dont think it should fail the validation. It is not invalid data. it is just empty data which i think in terms of releases is okay. Will just return a empty list of releases.

Logging why a release should be kept, Console.WriteLine() great if you are debugging. Production though, you want something better, so i think putting the logs into a JSON file with extra information like dates etc. would be good for logging.

### GENERAL THOUGHTS
So my approach to the solving the Release Rentention rule, looping over everything starting at projects then environments, get all the deployments, then releases. Simple, easy? maybe, but nested loops hurt the soul to look at. 
No databases, but all this data is connected, so connect it without a database. Dont need to loop over projects and environments, just create the combinations for each project / enviroment by grouping them, find all the deployments and releases that relate to them and come at it from that angle.
Can use LINQ and connect what i need together.
Edges cases with data can be painful, trying to make your code handle them all is not a good way to go about it, So if i can validate all the data before. i can setup the rule knowing that my data is correct. Keeps my code cleaner and easier to read.
Tests, test everything within reason of course. Time spent thinking about testing can save you time debugging in the future. 


### IDEAS AND IMPROVEMENTS
Have another method that instead of returning the releases, it deletes the releases that are not getting kept or returns a list of releases to delete.

### USE OF AI ASSISTANCE
- What AI assistant(s) did you use for your exercise?
* I have a Github Copilot subscription, using the GPT-4.1 model.

- What did you ask AI to assist you with and why? 
* So this one isnt a what did i ask it, but just inline auto code completion. Sometimes it is really good at picking up what you are writting but not always, other times it constantly suggesting stuff is distracting.

* I asked it to help me get the correct file path in my ReleaseLogger.cs, i asked it because my first few attempts i couldnt get it in the actual working directoy, then it went into the bin folder. But i didnt want it in there for this exercise as there wasnt a need for it. So i got it to help me get it to where it logs now. I also asked it to help me be able to keep adding to the same file and limit its thread so it didnt have multiple calls coming to it all at once. The reasons i asked it for help with this, is i havent wrote to a JSON file like this before. I find using AI in these moments saves me alot of time googling and lets me learn what i am trying to figure out faster.

* I asked it to create test cases for me for my Validators, They are very simple logic, no crazy edge cases i have to worry about. I asked it to create them for me as it is a massive time saings. Despite it adding test cases for logic that didnt exist or some properties on a model that also did not exist.

* I got it to help me get my Deconstruct on the "public class ReleaseRetentionMockData" correct, i asked it to help as i have created methods using out before, but i had never done it on a Class before like that, so that was a cool new thing to learn. So many times before ive wrote tests that have something like testData.Projects, testData.Environments... having the out and just getting to use projects, envrionments... looks so much nicer.

* I asked it to spell check my work, because typing alot sometimes you miss a letter in a long method name and it is hard to pick that up when you have been looking at it for a while.

- How useful did you find the AI output?
* I found it super useful on the Logger and the Deconstruction for getting "Out" working. In those moments i find i learn really quick by seeing what it is doing and just been able to pin point exactly what i am trying to do, without having to context switch to google. 

* Its auto complete and test case creation, i find it kind of 50/50. Like it can see i am using xUnit for my tests but will use Nunit, that bugs me. But easy to remedy by just being more precise with what you are actually asking it. Very 50/50 overall on its output tho.

- What extra steps did you take before including it in your solution?
* So for the times id use the auto completion and getting it to write out test stuff, there is no extra steps i take. I feel confident in my knowledge that using it in those moments is just a way of been more efficent. 
* For the times i asked it something directly, my extra steps are trying it myself a few times until i feel stuck. Then i feel like reaching for it is the right move, as it is giving me the results id find on google just alot faster.


