"use client";

function MyButton({title}: {title: string}) {
  function clickEvent(){
    alert("Say Cheese!")
  }

return (
    <button onClick={clickEvent} className="bg-blue-500">{title}</button>
  );
}


function basicBih() {
  return "Spend Dat!"
}

function MyComponent() {
  const products = [
    { title: 'Cabbage', id: 1 },
    { title: 'Garlic', id: 2 },
    { title: 'Apple', id: 3 },
  ];

 const items = products.map(element =>
<p key={element.id}>{element.title}</p>
  )

  return (<div>{items}</div>);
}


export default function MyApp() {
  const result = basicBih();

  return (
    <div>
      <h1>Welcome to the Cozy App!</h1>
      <p>{result}</p>
      <MyButton title="Cozy Button 2.0"/>
      <MyComponent />
    </div>
  );
}