# Roteiro de Testes

- LOGIN 
  - Tentar acessar uma rota sem estar logado 
  - Validar token nulo 
  - Tentar fazer login com um username não cadastrado. 
  - Validar username não cadastrado 
  - Tentar entrar com username válido porém senha incorreta.
  - Validar senha inválida


  - Entrar com o usuário admin:
  ```json
  {
    "username": "admin",
    "password": "123@admin"
  }

    - Entrar com o usuário Instructor:
  ```json
  {
    "username": "instru",
    "password": "123@instru"
  }

    - Entrar com o usuário Student:
  ```json
  {
    "username": "instru",
    "password": "123@instru"
  }

  <------------------------------------------------------------------------>

  - ClassRoom

  - CREATE
    - Adicionar Nullo:
    ```json
      {
        "name": "",
        "description": "teste 01"
      }
    ```
    ```json
      {
        "name": "teste 02",
        "description": ""
      }
    ```

    - Adicionar uma Activity 
    - Passar valor invalido 
    - tentar passar valor nulo

      ```json
      {
      "title": "string",
      "description": "string",
      "classRoomId": 0,
      "dueDate": "2022-06-22T21:58:52.148Z",
      "arquives": [
        {
          "dataBase64": "string"
        }
      ]
      }
    ```

  - UPDATE
    - Validar ao editar um ClassRoom com ID inválido
    - Tentar Editar passando nulo
    - Não permitir salvar valor invalido ou nulo

    ```json
      {
        "name": "teste 03",
        "description": "teste 03"
      }
    
    ```

    - Validar ao editar um Activity com ID inválido 
    - Tentar Editar passando nulo
    - Não permitir salvar valor invalido ou nulo

    ```json
      {
          "title": "teste 04",
          "description": "teste 04",
          "classRoomId": 1,
          "dueDate": "2022-06-22T22:00:53.362Z",
          "arquives": [
            {
              "dataBase64": "string"
            }
          ]
      }
    
    ```
    
  - GET
    - Listar todos os ClassRoom 
    - Conseguir listar com filtro  
    - Buscar por Id
   
  - DELETE

     ClassRoom
    - Validar ao remover um Id ClassRoom inválido
    - Remover  

    Activity
    - Validar ao remover um Id ClassRoom inválido
    - Validar ao remover um Id Activity inválido
    - Remover 

  <------------------------------------------------------------------------> 

  -Instructor

  - GET
        - Listar todos os Instructor 
        - Listar Users Role
        - Buscar por Id

  - CREATE

      - passar valor nulo
      - passar valores duplicados
      - colocar um username que já existe
      - validar formato de email correto
      - validar password

      ```json
          {
              "name": "teste 04",
              "username": "teste",
              "email": "teste04@gmail.com",
              "password": "teste123@",
              "birthDate": "2022-06-22T22:05:26.439Z",
              "userRoleId": 0,
              "subjectId": 0
          }
    
        ```
     - UPDATE
        
      - Tentar editar com id que não existe
      - passar valor nulo
      - passar valores duplicados
      - colocar um username que já existe
      - validar formato de email correto
      - validar password

       ```json
          {
              "name": "teste 05",
              "username": "teste",
              "email": "teste04@gmail.com",
              "password": "teste123@",
              "birthDate": "2022-06-22T22:05:26.439Z",
              "userRoleId": 0,
              "subjectId": 0
          }
    
        ```

     - DELETE

       - Validar ao remover um Id ClassRoom inválido
       - Remover
            
  -Student

     - GET

        - Listar todos os Instructor 
        - Listar Users Role
        - Buscar por Id

     - CREATE

      - passar valor nulo
      - passar valores duplicados
      - colocar um username que já existe
      - validar formato de email correto
      - validar password
      - Validar formato do telefone 

       ```json
          {
              "name": "teste 06",
              "username": "teste 06",
              "email": "teste06@gmail.com",
              "password": "teste06@123",
              "birthDate": "2022-06-22T22:14:12.363Z",
              "userRoleId": 0,
              "responsiblePhone": "(11)98444-2222"
          }
        
        ``` 
      - UPDATE

          -Tentar editar com id que não existe
          - passar valor nulo
          - passar valores duplicados
          - colocar um username que já existe
          - validar formato de email correto
          - validar password

       ```json
          {
              "name": "teste 07",
              "username": "teste 07",
              "email": "teste07@gmail.com",
              "password": "teste07@123",
              "birthDate": "2022-06-22T22:14:12.363Z",
              "userRoleId": 0,
              "responsiblePhone": "(11)98444-2222"
          }
        
        ``` 

     - DELETE

       - Validar ao remover um Id ClassRoom inválido
       - Remover


    
  <------------------------------------------------------------------------> 