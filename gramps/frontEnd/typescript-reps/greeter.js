"use strict";
function greeter(person) {
    return "hello" + person.lastName;
}
class Student {
    firstName;
    midInitial;
    lastName;
    fullName;
    constructor(firstName, midInitial, lastName) {
        this.firstName = firstName;
        this.midInitial = midInitial;
        this.lastName = lastName;
        this.fullName = firstName + " " + midInitial + " " + lastName;
    }
}
let user = { firstName: "Jane",
    lastName: "Dope" };
let user1 = [0, 1, 2];
let stu = new Student("Mary", "J", "Dope");
document.body.textContent = greeter(stu);
//# sourceMappingURL=greeter.js.map