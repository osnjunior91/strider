
# StriderTeste
## Strider Web Back-end Assessment - 2.4

[![Build Status](https://travis-ci.org/joemccann/dillinger.svg?branch=master)](https://travis-ci.org/joemccann/dillinger)


## Tech

Software stack chosen  :

- [.NetCore](https://dotnet.microsoft.com/en-us/learn/dotnet/hello-world-tutorial/install)
- [ReactJs](https://reactjs.org/) 
- [EF Core](https://docs.microsoft.com/en-us/ef/core/get-started/overview/first-app?tabs=netcore-cli) 
- [Sql Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

- [Swagger](https://swagger.io/) 

##  Whats Including In This Repository

We have implemented below **strider repository**.

### Catalog
#### Post

- **Post - /api​/v1​/post** -  Where you can insert a new post.
- **Get- /api​/v1​/post** -  Where you can find a post.
- **Post - /api​/v1​/post/repost** -  Where you can insert a repost.
- **Get- /api/v1/post/following/{userId}** -  Where you can find a post of people you follow.

#### User
- **Post - /api/v1/user/follow** -  Where you can follow other user.
-  **Post - /api/v1/user/unfollow** -  Where you can unfollow other user.
- **Get- /api/v1/user/{id}** -  Where you can find a user by your id.
-  **Get-/api/v1/user/myposts/{id}** -  Where you can find posts by user id.
-  **Get-/api/v1/user/{userId}/follower/{followerId}** -  Where you can check if a user follows another user.

##  Run The Project

You will need the following tools:

* [Visual Studio 2019](https://visualstudio.microsoft.com/downloads/)

* [.Net Core 5 or later](https://dotnet.microsoft.com/download/dotnet-core/5)

* [SQL Server ](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

##  Installing

Follow these steps to get your development environment set up: 

1. Clone the repository
2. You need to access the **Strider.Infrastructure** project and run the migration commands:
```sh
Add-Migration InitialCreate -o Data/Migrations
update-database
```

After this there will be these tables in your database - **Followers**, **Posts**, **Users**
> Note: When you run migrations the project will create 3 users, if you want you can change, you must acess the class **DataContext**, where you can change insert new users.




MIT

**Free Software, Hell Yeah!**

[//]: # (These are reference links used in the body of this note and get stripped out when the markdown processor does its job. There is no need to format nicely because it shouldn't be seen. Thanks SO - http://stackoverflow.com/questions/4823468/store-comments-in-markdown-syntax)

   [dill]: <https://github.com/joemccann/dillinger>
   [git-repo-url]: <https://github.com/joemccann/dillinger.git>
   [john gruber]: <http://daringfireball.net>
   [df1]: <http://daringfireball.net/projects/markdown/>
   [markdown-it]: <https://github.com/markdown-it/markdown-it>
   [Ace Editor]: <http://ace.ajax.org>
   [node.js]: <http://nodejs.org>
   [Twitter Bootstrap]: <http://twitter.github.com/bootstrap/>
   [jQuery]: <http://jquery.com>
   [@tjholowaychuk]: <http://twitter.com/tjholowaychuk>
   [express]: <http://expressjs.com>
   [AngularJS]: <http://angularjs.org>
   [Gulp]: <http://gulpjs.com>

   [PlDb]: <https://github.com/joemccann/dillinger/tree/master/plugins/dropbox/README.md>
   [PlGh]: <https://github.com/joemccann/dillinger/tree/master/plugins/github/README.md>
   [PlGd]: <https://github.com/joemccann/dillinger/tree/master/plugins/googledrive/README.md>
   [PlOd]: <https://github.com/joemccann/dillinger/tree/master/plugins/onedrive/README.md>
   [PlMe]: <https://github.com/joemccann/dillinger/tree/master/plugins/medium/README.md>
   [PlGa]: <https://github.com/RahulHP/dillinger/blob/master/plugins/googleanalytics/README.md>
