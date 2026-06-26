function greeter(person: Person) {
    return "hello" + person.lastName;
}

interface Person {
    firstName: string;
    lastName: string;
}

class Student {
    fullName: string;
    
    constructor (public firstName: string, public midInitial: string, public lastName: string) {
        this.fullName = firstName + " " + midInitial + " " + lastName;
    }
    
}


let user = {firstName: "Jane",
            lastName: "Dope"};
let user1 = [0,1,2]

let stu = new Student("Mary", "J", "Dope")


document.body.textContent = greeter(stu);

