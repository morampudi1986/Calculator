const Color = (props) => {
    return (
        <div style={{ margin: '0.5em', display: 'inline' }}>
            <button name={props.name} onClick={props.click} style={{ backgroundColor: props.hex, width: props.width, height: props.height, color: props.color, cursor: props.cursor }} >
                {props.name}
            </button>
        </div>
    );
};

class Form extends React.Component {
    state = { colorClicked: '' }
    handleColorClick = (event) => {
        this.props.selected(event.target.style.backgroundColor, event.target.name);
    };
    render() {
        return (
            <div style={{ padding: '2em',borderStyle:'groove' }}><h1>Click on the below colors to calculate resistance</h1> <br /> <br />
                <div style={{ margin: '0.5em', display: 'inline' }}>
                    {this.props.colors.map(color => <Color key={color.name} {...color} click={this.handleColorClick} />)}
                </div>

            </div>
        );
    }
}


class SelectedColor extends React.Component {
    calculate = (event) => {
        this.props.calculateResistance();
    };
    render() {
        return (
            <div style={{ padding: '2em' }}><h1>Selected Band colors :</h1>

 <div style={{ margin: '2em', display: 'inline' }}>
                    {this.props.colors.map(color => <Color key={color.name} {...color} />)}
                    <button onClick={this.calculate} style={{ margin: '0.5em', display: this.props.calculate, cursor: "pointer" }}>Calculate </button>
                </div>


            </div>

        );
    }
}



class App extends React.Component {

    addColorInputs = (color, colorName) => {
        var text = "";
        if (this.state.userColorInputs.length == 4) {
            this.state.userColorInputs = [];
            this.state.postColors = [];
        }
        switch (this.state.userColorInputs.length) {
            case 0:
                text = 'A';
                break;
            case 1:
                text = 'B';
                break;
            case 2:
                text = 'C';
                break;
            case 3:
                text = 'D';
                break;

        }
        var selectedColor = {
            name: text,
            hex: color,
            color: "#696969",
            width: "25px",
            height: "60px",
            cursor: "text"
        };


        this.setState(prevState => ({
            userColorInputs: prevState.userColorInputs.concat(selectedColor),
            currentColorSelection: selectedColor,
            postColors: prevState.postColors.concat({ Name: colorName })
        }));
        if (this.state.userColorInputs.length >= 3) {
            this.state.displayCalculate = "inline";
        }
        else {
            this.state.displayCalculate = "none";
            this.state.showResult = "none";
        }
    }

    calculateResistance = () => {
        console.log("resistance calculated");
        var xhttp = new XMLHttpRequest();
        var app = this;
        xhttp.onreadystatechange = () => {
            if (xhttp.status == 200) {
                console.log("responseText" + xhttp.responseText);
                this.setState({
                    result: xhttp.responseText,
                    showResult: "block"
                });
            }
        };
        xhttp.open("POST", "/Home/Calculate?model="+JSON.stringify(this.state.postColors), true);
        xhttp.setRequestHeader("Content-Type", "application/json");
        //xhttp.send({ model: JSON.stringify(this.state.postColors) });
        xhttp.send();
        console.log(JSON.stringify(this.state.postColors));
    }

    state = {
        colors: [
            {
                name: "Pink",
                hex: "#FF69B4",
                color: "#696969",
                width: "55px",
                height: "35px",
                cursor: "pointer"
            },
            {
                name: "Silver",
                hex: "#C0C0C0",
                color: "#696969",
                width: "55px",
                height: "35px",
                cursor: "pointer"
            },
            {
                name: "Gold",
                hex: "#bf9b30",
                color: "#696969",
                width: "55px",
                height: "35px",
                cursor: "pointer"
            },
            {
                name: "Black",
                hex: "#000000",
                color: "#696969",
                height: "35px",
                cursor: "pointer"
            },
            {
                name: "Brown",
                hex: "#964B00",
                color: "#696969",
                height: "35px",
                cursor: "pointer"
            },
            {
                name: "Red",
                hex: "#FF0000",
                color: "#696969",
                width: "55px",
                height: "35px",
                cursor: "pointer"
            },
            {
                name: "Orange",
                hex: "#FFA500",
                color: "#696969",
                width: "55px",
                height: "35px",
                cursor: "pointer"
            },
            {
                name: "Yellow",
                hex: "#FFFF00",
                color: "#696969",
                width: "55px",
                height: "35px",
                cursor: "pointer"
            },
            {
                name: "Green",
                hex: "#9ACD32",
                color: "#696969",
                width: "55px",
                height: "35px",
                cursor: "pointer"
            },
            {
                name: "Blue",
                hex: "#6495ED",
                color: "#696969",
                width: "55px",
                height: "35px",
                cursor: "pointer"
            },
            {
                name: "Violet",
                hex: "#9400D3",
                color: "#696969",
                width: "55px",
                height: "35px",
                cursor: "pointer"
            },
            {
                name: "Gray",
                hex: "#A0A0A0",
                color: "#696969",
                width: "55px",
                height: "35px",
                cursor: "pointer"
            },
            {
                name: "White",
                hex: "#FFFFFF",
                color: "#696969",
                width: "55px",
                height: "35px",
                cursor: "pointer"
            }
        ],
        userColorInputs: [
        ],
        postColors: [],
        currentColorSelection: '',
        displayCalculate: 'none',
        result: 'none',
        showResult: 'none'
    };



    render() {
        return (
            <div>
                <Form colors={this.state.colors} selected={this.addColorInputs} />
                <SelectedColor calculateResistance={this.calculateResistance} colors={this.state.userColorInputs} calculate={this.state.displayCalculate} />
                <div style={{ padding: '2em', display: this.state.showResult }}><h1>Maximum Resistance for the selected band colors: {this.state.result}</h1>
                </div>
            </div>
        );
    }
}
ReactDOM.render(<App />, document.getElementById('content'));