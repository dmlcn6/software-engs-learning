"use strict";
function greeter(person) {
    return "Hello, " + person;
}
let user = "Jane User";
let user1 = [0, 1, 2];
document.body.textContent = greeter(user);
class student {
    firstName;
    middleInitial;
    lastName;
    fullname;
    constructor(firstName, middleInitial, lastName) {
        this.firstName = firstName;
        this.middleInitial = middleInitial;
        this.lastName = lastName;
        this.fullname = firstName + " " + middleInitial + " " + lastName;
    }
}
function greeter2(person) {
    return "Hello, " + person.firstName + " " + person.lastName;
}
let user2 = { firstName: "jane", lastName: "user" };
let stu = new student("Jane", "M.", "User");
document.body.textContent = greeter2(stu);
