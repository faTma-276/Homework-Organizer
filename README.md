# Homework Organizer
simple ASP.NET Core Web API for managing homework tasks for students. The API allows adding new homework tasks and marking them as completed. It includes validation for due dates (must be in the future) and is integrated with Swagger UI for testing. 
Features 
- Add a homework task (POST /api/homework/add) 
- Mark homework as completed (POST /api/homework/complete/{id}) 
- In-memory storage (List<HomeworkTask>) 
- Validates that DueDate is a future date 
- Swagger UI enabled for testing and documentation 
