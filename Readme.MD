Knowledge Path is an interactive subject pathfinder for the curious and unfocused mind to quickly hone in on an interesting topic.

An alpha version release is available as a [zipped folder](https://github.com/sourcenrao/KnowledgePath/releases/download/v0.2-alphaZIP/KPv0.2-alpha.zip) with an executable.

Starting with selected quotes or facts from the three primary branches of science - Formal, Life, and Natural, selecting the one most interesting to you will narrow the focus of the program.
Three more options are presented in based on the previous selection. Once a tree's endpoint has been reached, the subject tree path is shown to the user.

While building this project, I found existing research in the area which goes far beyond what I initially set out to do.
If you found the concept interesting, I recommend taking 10 minutes to check out ASU's me3 tool at [m3.careers](https://me3.careers/asu/landing).
Personally, it told me my top careers would be urban planner, database architect, and intelligence officer, so take it with a grain of salt.

_Features_:

* Main loop takes repeated input so the user can go through the path, quit at any time, and restart if desired.
* A JSON document holds the data for each category.
* An input parser validates and transforms what the user enters into a stored enum value.
* LINQ is used to work with the JSON file.
* The path taken by the user is stored and shown to the user at the end of their path.