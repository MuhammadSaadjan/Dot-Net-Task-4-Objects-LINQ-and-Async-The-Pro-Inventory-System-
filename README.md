Lambda Expressions — p => p.Name

A lambda is just a shortcut for writing a small function in one line without giving it a name.
The p is a variable I made up that represents each item in the list as LINQ goes through it.
The => arrow means "goes to" — so p => p.Price means "for each item p, give me its Price."
LINQ handles all the looping internally, I just tell it what to look at using the lambda.

LINQ vs Loops

A regular foreach loop makes me manually create a new list, loop through, check the condition, and add items myself.
LINQ does all of that in one line using methods like .Where(), .OrderBy() and .FirstOrDefault().
LINQ is harder to mess up because there are no off-by-one errors or forgotten .Add() calls.
It reads like English and chains together cleanly, so I can see exactly what the code is doing at a glance.

Task.Delay vs Thread.Sleep

Thread.Sleep(3000) freezes the thread completely for 3 seconds, nothing else can run during that time.
In a UI app, Thread.Sleep makes the whole window stop responding and look like it crashed.
await Task.Delay(3000) pauses the method but releases the thread so the runtime can use it for other things.
When the delay finishes, execution picks back up where it left off and the UI stays responsive the whole time.

Value vs Reference Types

Product is a class, which means it is a reference type — the list stores a pointer to where the object lives in memory, not the object itself.
So when I grab an item from the list and change a property, I am changing the actual object, not a copy.
If Product was a struct instead, the list would store a full copy and my changes would not affect the original.
Simple rule — class means one object shared everywhere, struct means every variable gets its own copy.


Research Question:  
async and await
async and await are basically a team — you never really use one without the other. The async keyword just marks a method and says "hey, this method is allowed to pause and resume." The await is where the actual pausing happens. When the code hits an await, it stops that method, releases the thread, and lets other things run. When the operation finishes, it picks back up right where it left off.
Without them, the code just runs line by line and waits for each thing to fully finish before moving on. That works fine for small stuff, but the moment you have something that takes time — like saving to a database — it becomes a real problem.

What happens without async in a real UI app
Imagine you click a Save button in an app and it needs to upload data to a cloud server, which takes 10 seconds. Without async, that 10 seconds completely locks the main thread — which is the same thread responsible for drawing the UI and responding to the user.
So the window freezes. Buttons stop working. On Windows you would see "Not Responding" in the title bar and the screen might turn white. The user has no idea if the app is working or if it crashed, so they might force close it and lose everything.
The save is still going to take 10 seconds either way. The difference is that with async, the thread is released during that wait, so the UI keeps running normally. The user can still interact with the app, maybe see a loading spinner, and the save completes in the background without anyone noticing.
The chef analogy honestly says it best — without async the chef stands at the microwave for 10 minutes doing absolutely nothing. With async the chef starts it, goes and does other work, and comes back when it beeps.
