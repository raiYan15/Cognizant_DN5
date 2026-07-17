public class MVCTest {

    public static void main(String[] args) {

        System.out.println("=== MVC Pattern - Student Record System ===\n");
        Student student = new Student("Alice Johnson", 1001, "A");
        StudentView view = new StudentView();
        StudentController controller = new StudentController(student, view);
        System.out.println("Initial Details:");
        controller.updateView();
        controller.setStudentName("Alice Smith");
        controller.setStudentGrade("A+");
        System.out.println("\nAfter Update:");
        controller.updateView();
    }
}
