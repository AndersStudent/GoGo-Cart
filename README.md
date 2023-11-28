# GoGo-Cart

Name: Anders Lucassen Lund

Student Number: 20224239

Link to Project: https://github.com/AndersStudent/GoGo-Cart.git

# Controls:
W = forward

A & D = turn

S = reverse

Space = use powerup

# Overview of the Game:
The game is like mario kart. The player controls a kart and needs to finish before the other karts. The karts can collect a power up that gives the kart an extra boost and ignore track traction, the player and the enemy can both use the power-ups. The Game has 3 laps and counts what place the karts are on, by who is on what checkpoint and how close they are to the next. The kart has an current speed, acceleration, top speed, turn speed and brake force. 

# The main parts of the game are:
Go kart driving with the WASD keys with the kart needing to power up and down again

A 3D driving track with the area outside of the path giving less traction

Power up that gives the user more speed and can be used with the Spacebar

Multiple AI drivers that don't take the exactly same path as the others

Checkpoints to see who is winning and how many laps has been done

Ui to display lap and position

# Game features:
Smoke particles when driving

Count down before the race starts

Slower reverse than forward driving

Speeding up when driving forward before hitting maxspeed

Slowing down when nothing og reverse is pressed

# How Different Course Components Were Utilized: 
The game comprises character utilize Unity's affine transformations for kart movement. Power-ups are respawned after a given time. AI checkpoint location is a random position in a given range within the racing arena using Unity's randomization functionality, with intervals calculated based on the size of the area. Object interactions, such as collisions between the player, power-ups, and rivals, are managed using Unity's collision system with onCollisionEnter events. A UI to display the power up and to show what lap and position the player was on. And particles to show dust/smoke from the karts when they drive. 

# Project Parts:
Scripts:
CheckPoint -used to check if a kart has entered the checkpoint and send the info back to the kart

Kart - Used to make the Player and enemy move, stores info about is place, lap, path and power-up

MistroyBox - The power up box that checks if a kart hits it and give the kart the power up

MistroyBoxSpawner - Spawns the mystery boxes after some time

Overview - Stores info like path, maxlap, karts, Ui, countdown

Tarraien - change the karts traction to change its speed to have less speed on the grass than on the path

# Models & Prefabs:
All models was made by myself in MagicaVoxel

https://ephtracy.github.io/

All prefabs was made by myself in unity

# Sprites:
All sprites was made by myself in aseprite

https://www.aseprite.org/

# Materials:
Basic MagicaVoxel materials for everything

# Scenes:
Game consists of one scene

# Testing:
Game was tested on Windows






# Used Resources:
Bit of chat gpt to inspire the driving movement for i had never made that before 
TextMesh Pro for text
MagicaVoxel for making models
Aseprite for making sprites
