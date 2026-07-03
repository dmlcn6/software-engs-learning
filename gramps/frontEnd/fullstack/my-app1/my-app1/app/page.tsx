"use client";

import { JSX } from "react/jsx-runtime";

function MyButton() {

  function handleClick() {
    alert("AYAOOO");
  }

  return (<button onClick={handleClick} className="bg-blue-500 rounded-md"> TEst </button>);
}


function basic() {
  return "Kay!"
}

function MyComponent({header}: {header:string}) {

  const products: {title:string, id:number}[] = [
  { title: 'Cabbage', id: 1 },
  { title: 'Garlic', id: 2 },
  { title: 'Apple', id: 3 },
];

  const items: JSX.Element[] = products.map(element => 
    <p key={element.id}>{element.title}</p>
  )

  return ( <div> <h1>{header}</h1> {items} </div> );
}

export default function MyApp() {

  const result = basic();

  

  return (
    <div >
      <p>{result}</p>
      <MyButton />
      <MyComponent header="WASSUP"/>
    </div>
  );
}