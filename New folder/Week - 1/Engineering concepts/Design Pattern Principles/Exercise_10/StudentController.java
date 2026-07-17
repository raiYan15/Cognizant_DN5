
public class StudentController {

    private Student model;
    private StudentView view;

    public StudentController(Student model, StudentView view) {
        this.model = model;
        this.view = view;
    }
    public String getStudentName() {
        return model.getName();
    }
    public void setStudentName(String name) {
        model.setName(name);
    }

    public String getStudentGrade() {
        return model.getGrade();
    }

    public void setStudentGrade(String grade) {
        model.setGrade(grade);
    }
    public void updateView() {
        view.displayStudentDetails(model.getName(), model.getId(), model.getGrade());
    }
}
