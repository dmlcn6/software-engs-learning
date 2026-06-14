function greeter(person: string) {
    return "Hello, " + person;
}

let user = "Jane User"
let user1 = [0, 1, 2];

document.body.textContent = greeter(user);

interface Person {
    firstName: string;
    lastName: string;
}

class student {
    fullname: string;
    constructor(
        public firstName: string, public middleInitial: string, public lastName: string) {
        this.fullname = firstName + " " + middleInitial + " " + lastName;
        }
}


function greeter2(person: Person) {
    return "Hello, " + person.firstName + " " + person.lastName;
}

let user2 = { firstName: "jane", lastName: "user" };
let stu = new student("Jane", "M.", "User");

document.body.textContent = greeter2(stu);