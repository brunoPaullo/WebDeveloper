import * as React from "react";
import * as ReactDOM from "react-dom";
import 'url-search-params-polyfill';
import { Hello } from "./components/Hello";

ReactDOM.render(
    <Hello compiler="webpack" framework="React"/>,
    document.getElementById("cibertec-app")
)