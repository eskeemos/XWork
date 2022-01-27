import { CircularProgress } from "@mui/material";
import React from "react";
import { Link } from "react-router-dom";

export default function Loader() {
    return (
        <CircularProgress id="loading" />
    );
}