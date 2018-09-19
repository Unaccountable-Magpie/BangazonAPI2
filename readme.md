# Building the Bangazon Platform API

ProductTypes Controller uses the ProductTypes & Products Model to run correctly. This controller allows you to Get a list of all objects
from the ProductsTypes table within the API using the GET method. You are able to add a new object to the table using the Post method. Using 
the PUT method will give you the access to update an object from the API. DELETE method will let you delete an object from the table inside the API
ONLY if it isn't associated to a product from the Products table.

**Purpose: Get, Post, Put, and Delete information from the ProductTypes table

**How it fits in context of the project: Allows the controller to access required information and other controllers that might need this information

**Specific Feature affected: Delete Method will only let you delete an object that has No association to a Product.

**How to test (Be thorough!):

1. Checkout to my branch ProductTypesController

2. type start BangazonAPI.sln

3. This will open the file inside Visual Studio and open ProductTypesController

4. Press IIS Express play button to start up the server, a window will open inside the browser. You will need to add /api/producttypes to end of the url in order to access my controller. Copy this address as you will need to paste inside Postman.
You can also open Powershell, cd into the project, and type dotnet run. Once the project is running, you will be supplied a local host url. Copy this address and use inside Postman instead of the Visual Studio url if you choose.
Only 1 option can be used at a time. You can not have the database running on both.

5. Open PostMan, and select GET

6. Copy that address from the browser inside there and press SEND

7. Select POST within PostMan

8. Add a new JSON object, you will be using the header selections at the top & click on Body, select Raw, and change Text to JSON
ex. { "Name": "Apparel"}

9. Rerun the GET and you should see a new object

10. Select PUT within PostMan

11. Update one of the JSON objects, you will still need the same url but add /2 on the end of it, click on Body, select Raw, and change Text to JSON
ex. { "id": 2, "name": "Toys"}

12. Rerun the GET and you should see the updated object

13. Select DELETE within PostMan

14. Delete one of the JSON objects, you will still need the same url but add /3 on the end of it. This will give you a 405 Method Not Allowed error. You are not allowed to delete a Product Type that is associated with a Product.

15. Delete one of the JSON objects, you will still need the same url but add /4 on the end of it(this should be the object that you created from your post). This will let you delete because there is
no association with a Product.

16. Rerun the GET and you shouldn't see that object because it was deleted

