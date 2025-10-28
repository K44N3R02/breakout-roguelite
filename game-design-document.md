# Game Design Document

## 1. Core Concept & Overview

### Game Title
[The working title of the game.]

### One-Sentence Pitch
[A concise, engaging summary of the game.]

### Genre
Roguelite and Arcanoid/Breakout hybrid

### Target Audience
Ages 7-77, casual/hypercasual players

### Platform(s)
Mobile (Android/iOS)

### Unique Selling Points (USPs)
[What makes this game stand out? (e.g., Innovative physics-based climbing mechanic).]

### Completion Estimate
3 months

## 2. Gameplay & Mechanics

### Core Loop (The "Moment-to-Moment")
Arcanoid > Level Up > Loop

### Player Controls & Interface
#### Input Map
For mobile devices, the paddle will follow the relative drag by touch input.
For debuging, desktop builds will follow coordinate of mouse.

#### Heads-Up Display (HUD)
For Arcanoid phase, player's lives, current game level, and active perks are shown.
For Level Up/Shop phase, again player's lives, last game level, their gold are shown.

#### Menus
Main Menu: New Game, Continue Play, Credits, Settings, About
Pause Menu: Resume, Exit, Settings
Settings: Master Volume, Music Volume, Sound FX Volume
Credits: Static text of used assets' creators
About: Static text about game and its creators

### Core Mechanics
#### Movement
Paddle moves in x-axis

#### Interaction
Paddle-Ball: Ball continues to move away from the paddle after collision
Paddle-Perk:
Paddle-Gold:
Paddle-Block:
Ball-Block: Ball damages the block and continues moving normally after reflection
Ball-Perk:
Ball-Portal:
Ball-Wall:
Deadzone-Ball:
Deadzone-Perk:
Deadzone-Gold:
Deadzone-Block:
Portal-Perk:
Portal-Gold:
Bullet-Block:
Bullet-Ball:
Bullet-Perk:
Bullet-Gold:
Bullet-Portal:
Bullet-Wall:

#### Physics
No gravity effects will be present.
No drag force or friction will be present.
All collisions are perfectly elastic and conservative.

### Game Progression & Structure
Level/World Design: Procedurally generated (probably wave function collapse) Arcanoid levels
Difficulty Scaling: Yet to be discussed after implementing mechanics
Win/Loss Conditions: Player lose the run if they lose all their healths. They win a level in a run when they clear all blocks in it. Run does not end until player loses.

## 3. Story, Lore, & World
No narrative elements are planned.

## 4. Art & Audio

### Art Direction
Visual Style: [Cel-shaded 2D, Realistic 3D, Pixel Art with dynamic lighting.]
Color Palette: [Dominant colors and mood they convey.]
Key Art/Concept Imagery: [Reference images or existing concept art links/references.]

### User Interface (UI) & User Experience (UX)
UI Style: [How do menus look and feel? (e.g., Minimalist, Diegetic, Steampunk).]
Font: [Chosen font and its style.]
Usability Goals: [e.g., All actions should be accessible within two clicks.]

### Sound & Music
Soundscape: [The general atmosphere of the world (e.g., Echoing, industrial, natural).]
Music: [Moods for different situations (e.g., Ambient for exploration, driving percussion for combat).]
Voice Acting: [Scope and style (e.g., Full VA for all major characters).]

## 5. Technical, Budget, & Schedule

### Technical Specifications
Engine: [e.g., Unreal Engine 5, Unity, Custom Engine.]
Tools: [Software to be used (e.g., Blender, Photoshop, Git, JIRA).]
Target Hardware: [Minimum and Recommended PC specs, Console requirements, Mobile OS versions.]

### Team & Management
Team Structure: [Roles needed (e.g., Lead Programmer, 2x Artists, Level Designer).]
Monetization Model: [How will the game make money? (e.g., Full price, F2P with cosmetics, Subscription).]
Marketing Plan: [Initial thoughts on promotion (e.g., Social media campaign, Steam demo).]

### Milestones & Schedule
Pre-Production: [Prototype completion date.]
Alpha: [Feature complete date.]
Beta: [Content complete, Bug fixing start date.]
Gold Master: [Final release version date.]

## 6. Post-Release & Appendix

### Post-Launch Content
[DLC, Expansions, new features, or seasonal events.]

### Community Support
[Plan for patches, bug fixes, and community engagement.]

### Reference Games ("Pillars")
[A list of games that heavily influence the design (e.g., The feel of 'Dark Souls,' the building of 'Minecraft').]
[Links to inspirational material, mood boards, or detailed flowcharts.]

