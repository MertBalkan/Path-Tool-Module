# Path-Tool-Module
For Unity in C# written path tool

## About
This tool helps you manage your points and save your points in the Unity Editor with Path Manager script.

## Features
<ul>
<li>Visualising the paths in the Unity editor</li>
<li>Using different algorithm settings</li>
<li>Creating and manipulating paths</li>
<li>Randomizing path spawn point</li>
<li>Showing distances between linear paths</li>
</ul>

## Installation
At the installation part, you can download this package using Unity's Package Manager.


* Firstly, click the `Code` button of this repository 

![step1a](https://user-images.githubusercontent.com/43827959/207102079-8a8e931d-d2e2-4423-ba57-c75f7116b0f8.png)


* After that, copy the path of this package.

![step1b](https://user-images.githubusercontent.com/43827959/207103519-0cddce23-978d-4226-9d08-f4ce903cc6a0.png)


* Then, go to `Unity Editor/Window/Package Manager` path from your editor.

![step1](https://user-images.githubusercontent.com/43827959/207101010-342e4329-c2d3-4798-b3cc-3a609ecb849c.png)


* At the package manager, click the `+` icon then select the `Add package from git URL...` section.

![step2](https://user-images.githubusercontent.com/43827959/207104188-bcd57894-1c1e-4457-a6e1-2e39f2337e72.png)

* After selecting that option, now you can paste the git path to here and press the `Add` button.

![step4](https://user-images.githubusercontent.com/43827959/207104455-cdb09520-13da-4a7a-a878-11bba37f26d2.png)

* Finally, you have successfully added this package to your project!

![step5](https://user-images.githubusercontent.com/43827959/207104959-5a983d3e-2c3c-436f-892c-26b6a9ac3ad3.png)

## Getting started
* At the getting started part, we will add `Path Manager Script` to the GameObject and figure it out that how the system works. 
Firstly, let's create empty GameObject and call it `Path Manager`

https://user-images.githubusercontent.com/43827959/206876553-e75972e9-f18e-4541-9645-24e122362b25.mp4

* After creating our `Path Manager` GameObject, we need to assign Path Manager script to it. 
* After assigning it to the Path Manager script, We'll see that on the Inspector panel some settings for this object.
* We can expand the `Editor Elements` part for seeing more options. At this part, we can give some sort of random values for the points and spawn them randomly at the Editor.


https://user-images.githubusercontent.com/43827959/207105802-a873f19c-fbf9-49c9-b0e3-29dfa7a02171.mp4

* You can add or delete any point in Runtime. 

https://user-images.githubusercontent.com/43827959/207107871-9548bf08-43c3-4340-a61d-e77bb6cc1eb4.mp4

* Selecting algorithm whether Catmull Rom or Linear. If it's using Linear Algorithm option, then it can show the distances between the points if it's selected at the Editor. 

https://user-images.githubusercontent.com/43827959/207107884-303a7359-ef60-4026-a2e9-56e7b0fd26d3.mp4

* Also we can delete the points that given any index below the path manager of it.


https://user-images.githubusercontent.com/43827959/207107939-e49bf44c-c05d-4a36-973e-4f5b4d22ebde.mp4



## License
This code is released under MIT license. Modify, distribute, sell, fork, and use this as much as you like. Both for personal and commercial use. I hold no responsibility if anything goes wrong.
If you use this, you don't need to refer to this repo, or give me any kind of credit but it would be appreciated. At least a ⭐ would be nice.

## Contributing
Pull Requests are welcome. 
But, note that by creating a pull request you are giving me permission to merge your 
code and release it under the MIT license mentioned above.

## Need Support?
In case of any issue you can submit an issue for this repository. Also don't forget to use tickets for your issue. 
So that way I can notice the issue easier.

## Support Me
You can support me from github sponsors or <a href="https://www.buymeacoffee.com/mertbalkan">buy me a coffee ☕</a>
