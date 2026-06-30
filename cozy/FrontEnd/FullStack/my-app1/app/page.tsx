function MyButton() {
  return (
    <button className="bg-blue-500">Cozy Button</button>
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
  let result = basicBih();

  const products = [
    { title: 'Cabbage', id: 1 },
    { title: 'Garlic', id: 2 },
    { title: 'Apple', id: 3 },
  ];

  return (
    <div>
      <h1>Welcome to the Cozy App!</h1>
      <p>{result}</p>
      <MyButton />
      <MyComponent products />
    </div>
  );
}