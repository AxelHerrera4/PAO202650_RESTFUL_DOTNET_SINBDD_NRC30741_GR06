export default function LoginVista({ username, password, loginError, onUsernameChange, onPasswordChange, onSubmit }) {
  return (
    <div className="desktop-shell login-shell">
      <div className="login-layout">
        <section className="login-hero">
          <h1>MONSTER</h1>
          <h2>Sistema de Conversion RESTful</h2>
          <p>Temperatura, Masa y Longitud en una interfaz profesional.</p>
          <span>Acceso protegido ESPE - GR06</span>
        </section>

        <form className="login-panel" onSubmit={onSubmit}>
          <h3>Iniciar sesion</h3>
          <label>
            Usuario
            <input value={username} onChange={(e) => onUsernameChange(e.target.value)} />
          </label>
          <label>
            Contraseña
            <input type="password" value={password} onChange={(e) => onPasswordChange(e.target.value)} />
          </label>
          {loginError && <div className="error-text">{loginError}</div>}
          <div className="login-actions">
            <button type="submit" className="primary-btn">Ingresar</button>
          </div>
        </form>
      </div>
    </div>
  )
}
