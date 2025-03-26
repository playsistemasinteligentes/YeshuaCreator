import { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import { Button, Input } from "@/components/ui/button";
import { Card, CardContent } from "@/components/ui/card";
import { Menu } from "@/components/ui/menu";

const API_BASE = "http://localhost:5162";

export default function App() {
  const [token, setToken] = useState(localStorage.getItem("token") || "");
  const [menu, setMenu] = useState([]);
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");
  const navigate = useNavigate();

  const login = async () => {
    const response = await fetch(`${API_BASE}/Login`, {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify({ username, password }),
    });
    const data = await response.json();
    if (data.token) {
      localStorage.setItem("token", data.token);
      setToken(data.token);
      fetchMenu(data.token);
    }
  };

  const fetchMenu = async (authToken) => {
    const response = await fetch(`${API_BASE}/getMenu`, {
      headers: { Authorization: `Bearer ${authToken}` },
    });
    const data = await response.json();
    setMenu(data);
  };

  useEffect(() => {
    if (token) fetchMenu(token);
  }, [token]);

  return (
    <div className="flex flex-col md:flex-row min-h-screen">
      {token ? (
        <Menu menuItems={menu} />
      ) : (
        <Card className="m-auto p-6 max-w-sm w-full">
          <CardContent>
            <Input
              type="text"
              placeholder="Usuário"
              value={username}
              onChange={(e) => setUsername(e.target.value)}
              className="mb-4"
            />
            <Input
              type="password"
              placeholder="Senha"
              value={password}
              onChange={(e) => setPassword(e.target.value)}
              className="mb-4"
            />
            <Button onClick={login} className="w-full">
              Login
            </Button>
          </CardContent>
        </Card>
      )}
    </div>
  );
}

function Menu({ menuItems }) {
  return (
    <nav className="bg-gray-800 text-white w-full md:w-60 h-screen p-4">
      <ul>
        {menuItems.map((item) => (
          <li key={item.id} className="mb-2">
            <a href={item.endpoint} className="block p-2 hover:bg-gray-700">
              {item.description}
            </a>
          </li>
        ))}
      </ul>
    </nav>
  );
}
