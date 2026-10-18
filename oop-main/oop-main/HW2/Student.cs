
import java.util.Scanner;

public class Main {
    static Scanner sc = new Scanner(System.in);

    public static Person inputPersonInfo(
            String name, String address, String sSalary)
            throws Exception {

        if (name == null || name.trim().isEmpty()
                || address == null || address.trim().isEmpty()) {
            throw new Exception("You must input Salary.");
        }

        if (sSalary == null || sSalary.trim().isEmpty()) {
            throw new Exception("You must input Salary.");
        }

        double salary;

        try {
            salary = Double.parseDouble(sSalary);
        } catch (NumberFormatException e) {
            throw new Exception("You must input digit.");
        }

        if (salary <= 0) {
            throw new Exception("Salary is greater than zero");
        }

        return new Person(name, address, salary);
    }

    public static void displayPersonInfo(Person person) {
        System.out.println("Information of Person you have entered:");
        System.out.println("Name:" + person.getName());
        System.out.println("Address:" + person.getAddress());
        System.out.println("Salary:" + person.getSalary());
    }

    public static Person[] sortBySalary(Person[] person)
            throws Exception {

        if (person == null || person.length == 0) {
            throw new Exception("Can't Sort Person");
        }

        try {
            for (int i = 0; i < person.length - 1; i++) {
                for (int j = 0; j < person.length - 1 - i; j++) {
                    if (person[j].getSalary()
                            > person[j + 1].getSalary()) {

                        Person temp = person[j];
                        person[j] = person[j + 1];
                        person[j + 1] = temp;
                    }
                }
            }

            return person;
        } catch (Exception e) {
            throw new Exception("Can't Sort Person");
        }
    }

    public static void main(String[] args) {
        Person[] person = new Person[3];

        System.out.println("=====Management Person programer=====");

        for (int i = 0; i < person.length; i++) {
            while (true) {
                try {
                    System.out.println("Input Information of Person");

                    System.out.print("Please input name:");
                    String name = sc.nextLine();

                    System.out.print("Please input address:");
                    String address = sc.nextLine();

                    System.out.print("Please input salary:");
                    String sSalary = sc.nextLine();

                    person[i] = inputPersonInfo(
                            name, address, sSalary);

                    break;
                } catch (Exception e) {
                    System.out.println(e.getMessage());
                    if (e.getMessage().equals("You must input Salary.")
                            || e.getMessage().equals("You must input digit.")
                            || e.getMessage().equals(
                                    "Salary is greater than zero")) {
                        System.out.print("Please input salary:");
                        String sSalary = sc.nextLine();

                        try {
                            person[i] = inputPersonInfo(
                                    "Temp", "Temp", sSalary);
                            break;
                        } catch (Exception ex) {
                            System.out.println(ex.getMessage());
                        }
                    }
                }
            }
        }

        try {
            person = sortBySalary(person);

            for (Person p : person) {
                displayPersonInfo(p);
            }
        } catch (Exception e) {
            System.out.println(e.getMessage());
        }
    }
}
