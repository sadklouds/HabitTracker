# HabitTracker
Console program of adding and tracking habits to an SQLite Database using CRUD Operations

# Given Requirements:
- [x] Application register habbits
- [x] This habit can't be tracked by time (ex. hours of sleep), only by quantity (ex. number of water glasses a day)
- [x] User can add a unit measurment for habit if they wish (KM. L, Milese etc)
- [x] The application should store and retrieve data from a real database
- [x] When the application starts, it should create a sqlite database, if one isn’t present.
- [x] It should also create a table in the database, where the habit will be logged.
- [x] The app should show the user a menu of options.
- [x] The users should be able to insert, delete, update and view their logged habit.
- [x] Handle all possible errors so that the application never crashes.
- [x] can only interact with the database using raw SQL. You can’t use mappers such as Entity Framework.

# Features

SQLite database connection
 - The program uses a SQLite db connection to store and read information.
 - If no database exists, or the correct table does not exist they will be created on program start.

A console based UI where users can navigate by int inpout from keyboard



CRUD DB functions
  - From the main menu users can Create, Read, Update or Delete entries for whichever date they want, entered in DD-MM-YYYY format.
  - Dates inputted are checked to make sure they are in the correct and realistic format.
  - Numeric and titles/units are type checked before an attempt of string in the database

# Challenges 

- Date and time was a hurdle for me to store correcty within the sqlite database as I was trying to learn the SQL command sytax correctly.
  one issue was converting the string date from the database back to a DateTime type when being added to a Habit object for viewing within the program.
  Which was resloved by looking into sql conversion methods.
  
- Knowing what to split into different classes in order to reduce/prevent having spahgetti code, too many function were in one class which has been cleaned up for now,
  but is still a problem 
  
- Before this point I had never used SQLite before in c# which lead me to learn on how to use SQL commands to interact with the crud operation I had created,
  the sql command I found where UPDATE, INSERT, SELECT AND DELETE.

  
# Lessons Learned

  - Before I start coding I should first sit down and design/map some op the classes and methods that need to be used; Rather then jumping straight in and using-
    trial and error up to completion. This will save more time and headaches in the future.
    
  - Do it the right way the first time. There were several instances where I just wanted to see if something would work.
    so I did it in a quick way in which I knew it would need to be fixed or cleaned up later. 
    
  - The reliance on using static methods in order to transfer data to difference classes and enitialising the data base and connection string.
    I now unserstand that static types should be used sparnigly as it can cuase issues of changing data thast should not be changed. To fix this I created Interface,
    for creating and accessing the data base, this way I could have a class for sqlite database and add another class for a different type of database later down the line.
    
# Areas to Improve
    
  - Learn more about the shortcuts within Visual studio in order to increase my productivity when coding. At the momment I only know about the refactirng of shared names,
      shortcut.
    
  - I need to learn more about using databases and move on from using SQLite in order to further my knwolege ane coding experince.
    
  - Apply more single reposnibilty to classes and methods, my logic class and and sql access classes are doing to much and should be split into smaller classes
    and methods.
    
# Resources Used

  - The help and advice of my mentor Cappuccinocodes
  
  - IamTimCorey youtube sql video series 
  
  - MS docs for setting up SQLite with C#
  
  - MS docs for DateTime 
  
  - Various StackOverflow articles
      
