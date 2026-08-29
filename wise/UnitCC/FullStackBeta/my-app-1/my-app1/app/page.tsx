"use client";

function MyButton({ title }: { title: string }) {
  
  function handleClick() {
    alert('A BAD FILE HAS SUCCESSFULLY BEEN INSTALLED!');
  }
  
  return (
    <button onClick={handleClick}>{title}</button>
  );
}


export default function MyApp() {
  return (
    <div>
      <h1>Welcome to my app</h1>
      <MyButton title="DO NOT CLICK ME!" />
    </div>
  );
};