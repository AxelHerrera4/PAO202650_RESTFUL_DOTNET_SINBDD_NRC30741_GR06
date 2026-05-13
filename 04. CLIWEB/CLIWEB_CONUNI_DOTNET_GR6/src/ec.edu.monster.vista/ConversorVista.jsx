import { getOperaciones } from '../ec.edu.monster.modelo/ConversorModelo.js'

export default function ConversorVista({
  category, opCode, valor, resultado, unidadOrigen, unidadDestino,
  onCategoryChange, onOpCodeChange, onValorChange, onConvert, onLimpiar, onLogout
}) {
  const operations = getOperaciones(category)

  return (
    <div className="desktop-shell">
      <div className="desktop-window">
        <header className="window-header">
          <h1>CONVERSOR MONSTER | {category.toUpperCase()}</h1>
        </header>

        <main className="converter-card">
          <label className="field-label">Categoria</label>
          <select className="field-input" value={category} onChange={(e) => onCategoryChange(e.target.value)}>
            <option value="temperatura">Temperatura</option>
            <option value="longitud">Longitud</option>
            <option value="masa">Masa</option>
          </select>

          <label className="field-label">Operacion</label>
          <select className="field-input" value={opCode} onChange={(e) => onOpCodeChange(e.target.value)}>
            {operations.map(op => (
              <option key={op.code} value={op.code}>{op.label}</option>
            ))}
          </select>

          <label className="field-label">Valor</label>
          <input
            className="field-input"
            value={valor}
            onChange={(e) => onValorChange(e.target.value)}
            placeholder="0.00"
          />

          <section className="result-box">
            <strong>{resultado ?? '---'}</strong>
            <p>{unidadOrigen}</p>
            <p>{unidadDestino}</p>
          </section>

          <div className="buttons-grid">
            <button className="primary-btn" onClick={onConvert}>Convertir</button>
            <button className="secondary-btn" onClick={onLimpiar}>Limpiar</button>
            <button className="secondary-btn" onClick={onLogout}>Cerrar Sesion</button>
          </div>
        </main>
      </div>
    </div>
  )
}
