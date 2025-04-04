import React from 'react';
import { createRoot } from 'react-dom/client';
import App from './App';

const container = createRoot(document.getElementById("root"));
if(container) {
  const root = createRoot(container);

  root.render(<App />);
} else {
  console.error('Elemento com id "root" não encontrado no DOM.');
}