# taskSystem
manage tasks for users with swagger, ORM, postgres

#### Endpoints 
- GET /api/User
- POST /api/User
- GET /api/User/{id}
- PUT /api/User/{id}
- DELET /api/User/{id}

  | Endpoints | Route  |
|---|---|
| GET | **/listCars** |
| POST | **/api/User** |
| GET | **/api/User/{id}** |
| PUT | **/api/User/{id}** |
| DELETE | **/api/User/{id}** |

```mermaid
classDiagram
    class UserModel {
        +Id: int
        +Name: string?
        +Email: string?
    }

    class TaskModel {
        +Id: int
        +Name: string?
        +Description: string?
        +Status: TaskStatus
    }

    class UserController {
        -_userRepository: IUserRepository

        +UserController(userRepository: IUserRepository)
        +FindAllUsers(): ActionResult<List<UserModel>>
        +FindById(id: int): ActionResult<UserModel>
        +Create(userModel: UserModel): ActionResult<UserModel>
        +Update(id: int, userModel: UserModel): ActionResult<UserModel>
        +Delete(id: int): ActionResult<bool>
    }

    class IUserRepository {
        +FindAllUsers(): Task<List<UserModel>>
        +FindById(id: int): Task<UserModel>
        +Add(userModel: UserModel): Task<UserModel>
        +Update(userModel: UserModel, id: int): Task<UserModel>
        +Delete(id: int): Task<bool>
    }

    UserModel <-- UserController : _userRepository
    TaskModel <-- UserController : _userRepository
```
