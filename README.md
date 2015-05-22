#Joomiz.Blog

![Build status](https://ci.appveyor.com/api/projects/status/mmx3ro53hhlvxiuq)


Simple C# blog system using Domain Driven Design.

##Pre-requisites

- Visual Studio 2013 Community

##Specifications

- As an author I can view posts.
- As an author I can publish a post.
- As an author I can associate a post in one or more categories.
- As an author I can save a post draft.
- As an author I can edit a post.
- As an author I can delete a post.
- As an author I can view comments by status.
- As an author I can approve a comment.
- As an author I can reject a comment.
- As an author I can delete a comment.
- As an author I can add a category.
- As an author I can edit a category.
- As an author I can delete a category.
- As an author I can add new authors.
- As an author I can delete an author.
- As a reader I can view posts.
- As a reader I can add comments.
- As a reader I can filter posts by category.
 
##Rules

- Only authorized authors can publish posts.
- Only authorized authors can add or delete authors.
- All authors can save post drafts.
- All authors can approve, reject or delete comments.
- All authors can add, edit or delete categories.
- Only Categories with no posts can be deleted.
