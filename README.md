# FightGame

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
