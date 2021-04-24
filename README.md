# Gesture Project - Myo Armband - Banshee Hunter

### **Myo Armband Description**
The Myo armband is a gesture controller that triggers a variety of actions on the computer based on the contractions of your muscles and the movements of your arm. It is intended for a variety of applications like controlling a slideshow presentation, controlling video playback while you're AFK, gaming, and more. We couldn't help but peek inside to take a closer look at how this interesting design was put together.

### **Project Specification:**
Develop an application with a Natural User Interface. There are a number of options available to
you and this is an opportunity to combine a lot of technology that you have worked with over the
past four years.

At the very least, this should be a local implementation of the application using gestures to interact
with it. For example, a voice controlled application fits the parameters of gesture based control. You
can expand out to include real-world hardware and use this as an opportunity to prove a concept.
The Internet of Things is a common phrase, so you could implement a solution taking advantage of
hardware like the Raspberry Pi, using the cloud for data transfer and creating a real-world scenario
through this medium. 

### **Introduction**
For this Project, the idea that was to develop an application that uses natural user interface. So with this, It was decided to make a first person training Simulator using the Myo Armband (Myo) and demonstrate how the Myo works. Using Unity, the application was to demonstrate how a Myo can be used by developing this game. Throughout this document, it will be describing how the application works and the gestures are used.

### **Purpose of the application**
The purpose of the application was to demonstrate how the Myo can track motions using motion sensors that track and detect a gesture depending activity of your muscles and arm movement. The Myo is a controller that can trigger variety of actions depending on the gesture that has been set in the game or application which would have instructions to set up and use. The electrical signal produced by a user muscles in the nervous system is called Electromyogram (EMG) signal. The EMG sensor that can determine the motion in the Myo. 
The project is built on Unity with the Myo. It is a demonstration in the use and function in how to use the Myo Armband. The project is first person shooter that can shoot enemies and look around the screen to hit them. Later decided using voice commands for the menu details. I wanted to not use the keyboard or mouse in this project once the game was activated.

The game has a high score that the player must beat to progress through the level and achieve a new high score by destroying the enemies in the level. Once the player dies then they get the chance to replay the level and try to achieve a new high score which is displayed back in the main menu.

## **Gestures identified as appropriate for this application**
The Myo Armband uses a variety of gestures to achieve a purpose. The Myo can be attached on your wrist or arm depending on the application. For this application the user must connect to the arm. Some gestures used in the project were making a fist, spreading your fingers and the movement of the Myo to look around the screen. The myo uses more as the image below shows:
 


In the project the myo devices needs to be connected first to active the level. The device was supplied by my lecturer which made it easier. The gestures used in the game/application are as follows: 

1.	The Player can use the Myo to look around the screen and aim at the direction of the enemies as the approach the player. The motion of the Myo is attached using a script which determine the direction of view which the camera follows.





2.	When the player has attached the Myo to themselves, making a Fist will shoot an bullet from the gun. The player will have to fire at the enemy to gain points to determine a high score. 



3.	Spreading your fingers to reposition the camera for viewing where the player will be face forward. This is because the position of the Myo can be adjust at times and can be hard to view the game from an angle. 



Voice Recognition commands were also used for the menu’s. Certain phrases used during the main menu and pausing the game and later described in detail all the rules that were used in the application.

The idea behind the application was to build a Unity 3D platform that showed how the Myo can be used in certain game. By adding the myo to this game, it demonstrated that how to shoot at enemies that approach the player and look in the direction of the enemies coming against the user. The only problem that was had with adding more gestures that had been already default in the Myo, was that it would be hard to distinguish between each gesture as some of the time the device would have a mind of its own. 

### **Hardware used in creating the application**
During the Process of the design of the project. There are 2 User Interfaces that are used in the development of this application: 
* Myo Armband 
* Voice Recognition 
#### **Myo Armband**
The device was given by the college, so the production was easier to determine and more flexible. The device is a lightweight elastic armband that expands to the users’ needs and has extra clips to tighten for the user. The myo armband was a high in demand product a few years ago but of recent but nowadays the number of applications has reduced in use of the product. Using the EMG electrodes, this can predict the signals from the person’s use of the device by their muscles being expanded are compressed on their arm or wrist. The information is then sent wireless to the connected device and used to predict an outcome depending on the situation.

#### **Setting up the device**
There is an application with instruction that a user can follow but first be downloaded and installed onto their computer device before use. Following the instruction can give the user a feel fo4r the gestures that the device uses and make sure the myo armband is connected to the computer device before running this application. Below are few of the instruction steps that are included in the process before completion of set up. With the completion of the instruction and the setup, the device should be fully set up and can be connected at any time. 
The myo as described above have a limited number of gestures that are fixed and only can be used. The device is wireless but must be connect first, to use the device with the application. In a 3D environment the device can be tricky and sometimes sensitive to a gesture depending on the user’s motion.   
The research conducted for this application was done by looking up other relative projects and testing out the Myo Armband with the project first-hand.  Finding tutorials or examples for connection of the myo to unity platform was difficult as a few of the videos were old and the website that outdated since 2020. A few videos examples were beneficial and contained relative information in the setting up of the device firstly to the computer or device.

#### **Voice Recognition**
With this Unity Application, Unity gives the option for voice recognition which has been adapted and used in this project by voice commands which the player can use for the main menu and pause menu options. The player has the option and choose for keyboard mouse input or voice commands or a bit of both with the same results. Below is a list of commands in each stage depending on the scene that is loaded.With this Unity Application, Unity gives the option for voice recognition which has been adapted and used in this project by voice commands which the player can use for the main menu and pause menu options. The player has the option and choose for keyboard mouse input or voice commands or a bit of both with the same results. Below is a list of commands in each stage depending on the scene that is loaded.

#### **Rules**
There are voice recognition commands that are used in the both scenes and can be operated through button clicking or saying the phrase. In the Main Menu, the player can use voice recognition to activate the commands on the screen instead of the buttons. In Level 1, the player can use voice recognition to activate the commands in that scene but there is a clause for the wrong voice input while the game is going. Only when the game is paused will this clause be activated. Below is the list of commands that the user can use during the game to get a result. Each heading describes where the command can be used and in each scene.

**Main Menu** – Only operated through the Main Menu Scene.
* **New Game** – New game is starting. 
  * Start Game, Begin Game.
*	**Quit Game** – quit the application.
    * Exit Game, End Game.

**Level 1 - Pause Menu** – During the Pause Menu Activated.
*	**Resume the Game** – Continue gameplay.
    *	Continue Game, Back to Game.
*	**Restart the Level** – Begin New Game.
    *	Restart game, restart level.
*	**Return to Main Menu** – Return back to Main Menu Scene.
    *	Back to Menu, Return to main menu.

Level 1 - Volume – During the Pause Menu Activated.
*	**Increase Volume** – On the slider the Increase volume will appear.
    *	Sound up, increase sound.
*	**Reduce Volume** – On the slider the Increase volume will appear.
    * Sound down, decrease sound.

### **Architecture**
The game is designed on Unity in a 3D environment where the player can look around the screen using the Myo Armband and Voice commands to activate certain function depending on the scene they are in. The aim of the game is getting the highest score possible until the player is defeated.

As stated above in the document the player uses a Myo Armband to control the actions of the player by looking around the screen to shoot the enemy before dying. 
*	Grammar Controller
    *	This script kept track of the phrases being said in the Scene and activated if phrase was said. There were 2 xml scripts made. One for the Main Menu page and one for the Level 1 Pause Menu.
*	Player Controller
    *	Here the script is added to the player character and shoots making a fist gesture.
*	Score Controller
    *	Keeps track of the Score and High Score.
*	Health Controller
    *	Recognizes the Health for the Player.


### **Conclusion**
From the beginning of the project, it was interesting to design a project using the Myo Armband(Myo). Some of the YouTube videos showed a Myo armband controlling a robot from an Arduino set. This would of being something that I would of being very excited to make if given enough time to complete but unfortunately the time was the problem. A future that I hope to make would be build something with Arduino as having the Arduino set myself. 

Connecting the device with the support application was interesting which explained a vast amount of detail and function which could be used in the project. There were a few setbacks that were identified early on from using the Myo. The Myo was recently bought out by google so there weren’t any support services to be contacted if the user ran into trouble. The website was taken down and outdated. The device would sometimes get warm unexpectedly which felt uncomfortable at times. The device was a bit too sensitive which I would a challenge to find the right controls for the application. Having a certain control for action would have its downfalls so having only a few would suit the application better.

But overall, the process and experience of getting the chance in designing an application was an experience and fun outcome.

### **References**
https://time.com/4173507/myo-armband-review/

https://www.robotshop.com/eu/en/myo-gesture-control-armband-black.html
