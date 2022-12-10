# FightGame
Welcome to our final project FightGame. Our main driver is a blazor UI. You will first be instructed to enter a class and a username. You can use that username later to pick up a saved game. You will then be given the option to play or quit. When you play, it will start you off against one our enemies. It will
randomly assign an enemy to fight you. You will have the option to Dodge, do a Normal Attack, do n Special Attack, or do a Ultimate Attack, but be careful because you only have so many dodges, specials, and ultimates.
To run the tests, use dotnet test. We have multiple tests testing for the players attacks, getting a player, enemy attacks, getting an enemy, the shop, etc. 
The main idea of how this works is that you have a player class and different character types that you can choose from. Those will decide what stats you have such as Damage and Defense. We have a game class that has some of our main functions such as selecting a character type, playerturns, enemy attacks, etc. There is also an inventory class that will keep track of how many ultimates, specials, and dodges you have. The inventory will be displayed so you'll know how many you have. After you win a game, our shop function will open giving you options for things to buy. You can buy more ultimates, specials, and dodges there.

## Player - Chris
    -Player has a base Damage, Defense, Health, and Weapon based on class. Stats can be improved later in the game
    -Player has a Name which will be entered in before the game starts
        -If the Name entered is a previously saved Username, the game will start the player with the stats and money from before
    -Player will have a set amount of money which they can use at the shop
    -Player will have a chance to do a random amount of critical hit damage
    -Player will have attacks that they can choose from
## Enemy - Ricardo
    -Enemy will have a Damage, Defense, Health, and Weapon.
    -Enemy will have a set Name
    -Enemy fought will be randomly generated?
    -Enemy will do a random attack based on a random generator
    -Enemy will have a chance to do a random amount of critical hit damage to the player
## Shop
    -Player will have an amount of money earned that they can use in the shop
    -Player will be able to upgrade damage, defense, health, etc.
    -Player will be able to buy healing potions?
## Game
    -Player and Enemy will take turns attacking each other
    -After a round, player will have the option to continue, quit, or go to the shop
    -Game will display the attacks that the player has available to him
    -Game will display player and enemy health
    -Game will determine amount of damage done to an enemy or the player
    -Set Difficulties?

## Todo List
    -Classes
        -create a player class
        -create an enemy class
        -create a game class that runs through the game
        -create a shop class, where players can purchase upgrades
    -Struct
        -Make a random critical hit generator struct
    -Enumerated type
        -Create an enum type to select an attack
    -Inheritence
        -the different classes will inherit from player. Whatever class the user selects, will be his class and the user will have the stats
        of the class selected
    -polymorphism
        -override the toString method to allow us to print the players stats in a specific format
    -A second polymorphism
    -Throwing exceptions and catching
        -will throw and catch an exception if the player selects an invalid class
    -own generic datatype. 
    -Properties
        -Player classes have damage, health, and defense properties, same with enemies
    -static member function
        -Shop items costs
        -PlayerAttack
        -EnemyAttack
    -Interface
    -Second interface
    -two different built in generic collection types
