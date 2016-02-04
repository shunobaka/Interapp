# Routes description (Idea in progress)
## Public Area (visible to everyone)
- /
  - /home
    - GET - Home page with general info
  - /about
    - GET - About page with extended info on the project
  - /contacts
    - GET - Contacts page to provide contact info
- /universities
  - /universities/all
    - GET - provides a list of all universities and allows paging/sorting/filtering
  - /universities/info/:id
    - GET - provides extended info for the university
- /statistics
  - /statistics/index
    - GET - provides general statistics for the website
- /countries
  - /countries/index
    - GET - Provides a list of all countries with information about users and universities from there
  - /countries/info/:id
    - GET - provides info for a given country by id
## Student Area (Student role)
- /student/universities
  - /student/universities/add
    - GET - gets the form for adding universtity
    - POST - adds given university to the universities list for student
  - /student/universities/list
    - GET - gets a list of universities the student is interested in (provides filtering/paging/sorting)
- /student/applications
  - /student/applications/list
    - GET - gets a list of all applications the student submitted
  - /student/application/info/:id
    - GET - view info regarding given application
  - /student/application/preview/:id
    - GET - previews an application which is yet not sent
  - /student/application/sumbit
    - POST - sumbits a filled application
## Users Area (Logged in user)
- /user/profile
  - /user/profile/info
  - /user/profile/edit
- /users/:username
## Director Area (Director role)
- /director/universities
  - /director/universities/list
  - /director/universities/create
  - /director/universities/edit/:id
## Administration Area (Admin role)
- /admin/users
  - /admin/users/all
  - /admin/users/edit/:id
- /admin/universities
  - /admin/universities/all
  - /admin/universities/edit/:id
- /admin/statistics/
