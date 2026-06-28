function MyButton() {
    const result = [91,892,563];


    return (
        <div className="weather-data-hottest-2026">
            {result.map(x => {
                const sum = add(x,x);
                return (
                    <h1 key={x}>Hot Day {sum}</h1>
                )

            })}
        </div>
    )
}

function add(x, y) {
    return x+y;
}

export default function MyApp() {
    return (
        <div>
            <h1> Welcome</h1>
            <MyButton />
        </div>
    )
}