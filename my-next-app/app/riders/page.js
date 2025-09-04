"use client";

import { useState, useEffect } from "react";

export default function RytterPage() {
    const [ryttere, setRyttere] = useState([]);
    const [formData, setFormData] = useState({ navn: "", fødselsår: "", email: "" });
    const [loading, setLoading] = useState(true);

    const handleChange = (e) => setFormData({ ...formData, [e.target.name]: e.target.value });

    const handleSubmit = async (e) => {
        e.preventDefault();
        if (!formData.navn || !formData.fødselsår || !formData.email) return alert("Udfyld alle felter!");

        try {
            const response = await fetch("https://localhost:7205/api/rider", {
                method: "POST",
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify({
                    Name: formData.navn,
                    Email: formData.email,
                    BirthYear: parseInt(formData.fødselsår)
                })
            });

            if (!response.ok) throw new Error("Kunne ikke oprette rytteren");

            const newRytter = await response.json();
            setRyttere([...ryttere, newRytter]); // opdater listen med den nye rytter
            setFormData({ navn: "", fødselsår: "", email: "" });

        } catch (error) {
            console.error("Fejl ved oprettelse af rytter:", error);
            alert("Noget gik galt, prøv igen.");
        }
    };

    useEffect(() => {
        const fetchRyttere = async () => {
            try {
                const res = await fetch("https://localhost:7205/api/rider");
                if (!res.ok) throw new Error("Network response was not ok");
                const data = await res.json();
                setRyttere(data);
            } catch (err) {
                console.error("Error fetching riders:", err);
            } finally {
                setLoading(false);
            }
        };

        fetchRyttere();
    }, []);

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
            {loading ? (
                <p>Loading...</p>
            ) : (
                <ul className="list-disc pl-5">
                    {ryttere.map((r) => (
                        <li key={r.id}>
                            {r.name} ({r.birthYear}) - {r.email}
                        </li>
                    ))}
                </ul>
            )}
        </div>
    );
}
