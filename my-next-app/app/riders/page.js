// app/riders/page.js
"use client";

import { useState, useEffect } from "react";

export default function RytterPage() {
    const [ryttere, setRyttere] = useState([]);
    const [formData, setFormData] = useState({ navn: "", fødselsår: "", email: "" });
    const [loading, setLoading] = useState(true);

    const handleChange = (e) => setFormData({ ...formData, [e.target.name]: e.target.value });
    const handleSubmit = (e) => {
        e.preventDefault();
        if (!formData.navn || !formData.fødselsår || !formData.email) return alert("Udfyld alle felter!");
        setRyttere([...ryttere, formData]);
        setFormData({ navn: "", fødselsår: "", email: "" });
    };

    useEffect(() => {
        fetch("https://localhost:7205/api/rider")
            .then((res) => {
                if (!res.ok) throw new Error("Network response was not ok");
                return res.text(); // hent som tekst først
            })
            .then((text) => {
                if (!text) return []; // tomt svar håndteres
                return JSON.parse(text);
            })
            .then((data) => {
                setRyttere(data);
                setLoading(false);
            })
            .catch((err) => {
                console.error("Error fetching riders:", err);
                setLoading(false);
            });
    }, [])


    return (
        <div className="p-8 font-sans bg-gray-100 min-h-screen">
            <h1 className="text-2xl font-bold mb-4">Opret Rytter</h1>
            <form onSubmit={handleSubmit} className="mb-8 space-y-4">
                <div>
                    <label className="block mb-1">Navn:</label>
                    <input
                        type="text"
                        name="navn"
                        value={formData.navn}
                        onChange={handleChange}
                        className="border border-gray-300 rounded px-2 py-1 w-64"
                    />
                </div>
                <div>
                    <label className="block mb-1">Fødselsår:</label>
                    <input
                        type="number"
                        name="fødselsår"
                        value={formData.fødselsår}
                        onChange={handleChange}
                        className="border border-gray-300 rounded px-2 py-1 w-64"
                    />
                </div>
                <div>
                    <label className="block mb-1">Email:</label>
                    <input
                        type="email"
                        name="email"
                        value={formData.email}
                        onChange={handleChange}
                        className="border border-gray-300 rounded px-2 py-1 w-64"
                    />
                </div>
                <button type="submit" className="mt-2 px-4 py-2 bg-blue-500 text-white rounded hover:bg-blue-600">
                    Opret
                </button>
            </form>

            <h2 className="text-xl font-semibold mb-2">Liste over ryttere</h2>
            <ul className="list-disc pl-5">
                {ryttere.map((r, index) => (
                    <li key={index}>
                        {r.name} ({r.birthYear}) - {r.email}
                    </li>
                ))}
            </ul>
        </div>
    );
}