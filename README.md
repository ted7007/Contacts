# Contacts
web-api with contacts of person. 

main dto of person that come to responce:
      
       int? id 

       string firstName 

       string lastName 

       string middleName 

       string sex 

       string phoneNumber 

       DateTime birthday 

       string email 

       string VKLink 

       string discord 

       string address 

       string placeOfStudy 

       string workplace 
        
Also i have enum of sortState (options of sort persons):
        firstNameAscending,
        firstNameDescending,
        lastNameAscending,
        lastNameDescending,
        middleNameAscending,
        middleNameDescending,
        birthdayAscending,
        birthdayDescending,
        placeOfStudyAscending,
        placeOfStudyDescending,
        workplaceAscending,
        workplaceDescending

        
using this api you can do all commands of CRUD on this reference:
http://localhost:4000/api/v1/Person
get request: data IN - none; data out - list of dtos of persons; - request for get persons.

get request: data IN - id, using param in api: "/{id}"; data out - dto of persons; - request for get person on id.

get request: data IN - sortState, using param in api: "?sortState=value",
using values from enum of sortState, using param in api: "/{id}"; data out - list of dtos of persons; - request for get sorted persons.

post request: data IN - dto without id; data out - dto with id; - request for create person;

put request: data in - dto, data out - dto; - request for update person;


