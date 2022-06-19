Simple EF Core Project

There is a object called TaskItem which has informations about a simple Task.

TaskItem 
  - Id
  - Title
  - Description
  - Active


Its a simple crud which you can list for all tasks, or can chose about active or inactives ones.
There is a few patchs to update title and descrpiton. Also there is a possibility to activate ou deactivate a TaskItem.


On context I created the model and use migrations to update the database. I used SQLite to be faster 
