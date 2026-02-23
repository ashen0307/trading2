/* styles.css */

/* CSS Variables */
:root {
    --bg-primary: #0a0a0a;
    --bg-secondary: #141414;
    --bg-card: #1a1a1a;
    --bg-hover: #252525;
    --text-primary: #ffffff;
    --text-secondary: #b0b0b0;
    --accent-green: #00c853;
    --accent-green-hover: #00e676;
    --accent-red: #ff1744;
    --accent-red-hover: #ff4569;
    --accent-blue: #2962ff;
    --border-color: #2a2a2a;
    --success: #00c853;
    --danger: #ff1744;
}

/* Reset and Base */
* {
    margin: 0;
    padding: 0;
    box-sizing: border-box;
}

html {
    scroll-behavior: smooth;
}

body {
    font-family: system-ui, -apple-system, BlinkMacSystemFont, "Segoe UI", sans-serif;
    background-color: var(--bg-primary);
    color: var(--text-primary);
    line-height: 1.6;
    overflow-x: hidden;
}

/* Navigation */
.navbar {
    position: sticky;
    top: 0;
    background-color: rgba(10, 10, 10, 0.95);
    backdrop-filter: blur(10px);
    border-bottom: 1px solid var(--border-color);
    z-index: 1000;
    padding: 1rem 0;
}

.nav-container {
    max-width: 1200px;
    margin: 0 auto;
    padding: 0 2rem;
    display: flex;
    justify-content: space-between;
    align-items: center;
}

.logo {
    font-size: 1.5rem;
    font-weight: 700;
    color: var(--accent-green);
    letter-spacing: -0.5px;
}

.nav-menu {
    display: flex;
    list-style: none;
    gap: 2rem;
}

.nav-link {
    color: var(--text-secondary);
    text-decoration: none;
    font-weight: 500;
    transition: color 0.3s;
    position: relative;
}

.nav-link:hover {
    color: var(--text-primary);
}

.nav-link::after {
    content: '';
    position: absolute;
    bottom: -5px;
    left: 0;
    width: 0;
    height: 2px;
    background-color: var(--accent-green);
    transition: width 0.3s;
}

.nav-link:hover::after {
    width: 100%;
}

.mobile-menu-toggle {
    display: none;
    flex-direction: column;
    background: none;
    border: none;
    cursor: pointer;
    gap: 4px;
}

.mobile-menu-toggle span {
    width: 25px;
    height: 3px;
    background-color: var(--text-primary);
    transition: 0.3s;
}

/* Hero Section */
.hero {
    position: relative;
    min-height: 90vh;
    display: flex;
    align-items: center;
    justify-content: center;
    text-align: center;
    padding: 2rem;
    overflow: hidden;
}

.hero-bg {
    position: absolute;
    top: 0;
    left: 0;
    width: 100%;
    height: 100%;
    background: linear-gradient(135deg, rgba(0, 200, 83, 0.1) 0%, rgba(0, 0, 0, 0) 50%, rgba(255, 23, 68, 0.1) 100%);
    z-index: -1;
}

.hero-content {
    max-width: 800px;
    z-index: 1;
}

.hero h1 {
    font-size: 4rem;
    font-weight: 800;
    margin-bottom: 1rem;
    background: linear-gradient(135deg, var(--text-primary) 0%, var(--text-secondary) 100%);
    -webkit-background-clip: text;
    -webkit-text-fill-color: transparent;
    background-clip: text;
}

.subtitle {
    font-size: 1.25rem;
    color: var(--text-secondary);
    margin-bottom: 2rem;
}

.hero-buttons {
    display: flex;
    gap: 1rem;
    justify-content: center;
    flex-wrap: wrap;
}

/* Buttons */
.btn {
    padding: 1rem 2rem;
    border-radius: 8px;
    font-weight: 600;
    text-decoration: none;
    transition: all 0.3s;
    border: none;
    cursor: pointer;
    font-size: 1rem;
}

.btn-primary {
    background-color: var(--accent-green);
    color: #000;
}

.btn-primary:hover {
    background-color: var(--accent-green-hover);
    transform: translateY(-2px);
    box-shadow: 0 10px 20px rgba(0, 200, 83, 0.3);
}

.btn-secondary {
    background-color: transparent;
    color: var(--text-primary);
    border: 2px solid var(--border-color);
}

.btn-secondary:hover {
    border-color: var(--text-primary);
    background-color: var(--bg-hover);
}

/* Sections */
.section {
    padding: 5rem 2rem;
}

.container {
    max-width: 1200px;
    margin: 0 auto;
}

.section-title {
    font-size: 2.5rem;
    text-align: center;
    margin-bottom: 3rem;
    color: var(--text-primary);
}

/* Steps Grid */
.steps-grid {
    display: grid;
    grid-template-columns: repeat(auto-fit, minmax(250px, 1fr));
    gap: 2rem;
}

.step-card {
    background-color: var(--bg-card);
    padding: 2rem;
    border-radius: 12px;
    border: 1px solid var(--border-color);
    transition: transform 0.3s, border-color 0.3s;
    text-align: center;
}

.step-card:hover {
    transform: translateY(-5px);
    border-color: var(--accent-green);
}

.step-icon {
    font-size: 3rem;
    margin-bottom: 1rem;
}

.step-card h3 {
    margin-bottom: 0.5rem;
    color: var(--text-primary);
}

.step-card p {
    color: var(--text-secondary);
    font-size: 0.95rem;
}

/* Trading Section */
.trading-section {
    background-color: var(--bg-secondary);
}

/* Stats Bar */
.stats-bar {
    display: grid;
    grid-template-columns: repeat(auto-fit, minmax(150px, 1fr));
    gap: 1rem;
    margin-bottom: 2rem;
    background-color: var(--bg-card);
    padding: 1.5rem;
    border-radius: 12px;
    border: 1px solid var(--border-color);
}

.stat-item {
    text-align: center;
}

.stat-label {
    display: block;
    color: var(--text-secondary);
    font-size: 0.875rem;
    margin-bottom: 0.25rem;
}

.stat-value {
    display: block;
    font-size: 1.5rem;
    font-weight: 700;
    color: var(--text-primary);
}

.stat-value.win {
    color: var(--accent-green);
}

.stat-value.loss {
    color: var(--accent-red);
}

/* Trading Interface */
.trading-interface {
    display: grid;
    grid-template-columns: 1fr 350px;
    gap: 2rem;
    margin-bottom: 3rem;
}

@media (max-width: 968px) {
    .trading-interface {
        grid-template-columns: 1fr;
    }
}

/* Chart Area */
.chart-area {
    background-color: var(--bg-card);
    border-radius: 12px;
    border: 1px solid var(--border-color);
    overflow: hidden;
    position: relative;
}

.chart-header {
    display: flex;
    justify-content: space-between;
    align-items: center;
    padding: 1rem;
    border-bottom: 1px solid var(--border-color);
    flex-wrap: wrap;
    gap: 1rem;
}

.asset-info h3 {
    font-size: 1.25rem;
    margin-bottom: 0.25rem;
}

.price {
    font-size: 1.5rem;
    font-weight: 700;
    color: var(--text-primary);
}

.price-change {
    margin-left: 0.5rem;
    font-size: 0.875rem;
    color: var(--text-secondary);
}

.price-change.positive {
    color: var(--accent-green);
}

.price-change.negative {
    color: var(--accent-red);
}

.timeframe-selector {
    display: flex;
    gap: 0.5rem;
}

.tf-btn {
    padding: 0.5rem 1rem;
    background-color: var(--bg-hover);
    border: 1px solid var(--border-color);
    color: var(--text-secondary);
    border-radius: 6px;
    cursor: pointer;
    transition: all 0.3s;
    font-weight: 500;
}

.tf-btn:hover {
    background-color: var(--bg-primary);
    color: var(--text-primary);
}

.tf-btn.active {
    background-color: var(--accent-blue);
    color: white;
    border-color: var(--accent-blue);
}

#priceChart {
    width: 100%;
    height: 400px;
    display: block;
}

/* Trading Controls */
.trading-controls {
    background-color: var(--bg-card);
    padding: 1.5rem;
    border-radius: 12px;
    border: 1px solid var(--border-color);
    display: flex;
    flex-direction: column;
    gap: 1.5rem;
}

.control-group label {
    display: block;
    margin-bottom: 0.5rem;
    color: var(--text-secondary);
    font-size: 0.875rem;
    font-weight: 500;
}

.input-field {
    width: 100%;
    padding: 0.75rem;
    background-color: var(--bg-hover);
    border: 1px solid var(--border-color);
    border-radius: 8px;
    color: var(--text-primary);
    font-size: 1rem;
    transition: border-color 0.3s;
}

.input-field:focus {
    outline: none;
    border-color: var(--accent-blue);
}

.timeframe-buttons {
    display: grid;
    grid-template-columns: repeat(3, 1fr);
    gap: 0.5rem;
}

.tf-select {
    padding: 0.75rem;
    background-color: var(--bg-hover);
    border: 1px solid var(--border-color);
    color: var(--text-secondary);
    border-radius: 8px;
    cursor: pointer;
    transition: all 0.3s;
    font-weight: 500;
}

.tf-select:hover {
    background-color: var(--bg-primary);
    color: var(--text-primary);
}

.tf-select.active {
    background-color: var(--accent-blue);
    color: white;
    border-color: var(--accent-blue);
}

.trade-buttons {
    display: grid;
    grid-template-columns: 1fr 1fr;
    gap: 1rem;
    margin-top: 1rem;
}

.trade-btn {
    padding: 1.5rem 1rem;
    border: none;
    border-radius: 12px;
    cursor: pointer;
    transition: all 0.3s;
    display: flex;
    flex-direction: column;
    align-items: center;
    gap: 0.25rem;
    font-weight: 700;
}

.trade-btn.up {
    background-color: var(--accent-green);
    color: #000;
}

.trade-btn.up:hover {
    background-color: var(--accent-green-hover);
    transform: translateY(-2px);
    box-shadow: 0 10px 20px rgba(0, 200, 83, 0.3);
}

.trade-btn.down {
    background-color: var(--accent-red);
    color: #fff;
}

.trade-btn.down:hover {
    background-color: var(--accent-red-hover);
    transform: translateY(-2px);
    box-shadow: 0 10px 20px rgba(255, 23, 68, 0.3);
}

.btn-label {
    font-size: 1.25rem;
}

.btn-sublabel {
    font-size: 0.75rem;
    opacity: 0.9;
}

.payout-info {
    text-align: center;
    padding: 1rem;
    background-color: var(--bg-hover);
    border-radius: 8px;
    color: var(--text-secondary);
}

.payout-info strong {
    color: var(--accent-green);
    font-size: 1.25rem;
}

/* Trades Tables */
.trades-section {
    margin-bottom: 2rem;
}

.trades-section h3 {
    margin-bottom: 1rem;
    color: var(--text-primary);
}

.table-container {
    overflow-x: auto;
    background-color: var(--bg-card);
    border-radius: 12px;
    border: 1px solid var(--border-color);
}

.trades-table {
    width: 100%;
    border-collapse: collapse;
    font-size: 0.875rem;
}

.trades-table th {
    background-color: var(--bg-hover);
    padding: 1rem;
    text-align: left;
    color: var(--text-secondary);
    font-weight: 600;
    text-transform: uppercase;
    font-size: 0.75rem;
    letter-spacing: 0.5px;
    border-bottom: 1px solid var(--border-color);
}

.trades-table td {
    padding: 1rem;
    border-bottom: 1px solid var(--border-color);
    color: var(--text-primary);
}

.trades-table tr:last-child td {
    border-bottom: none;
}

.trades-table tr:hover {
    background-color: var(--bg-hover);
}

.empty-row td {
    text-align: center;
    color: var(--text-secondary);
    padding: 2rem;
}

.direction-up {
    color: var(--accent-green);
    font-weight: 600;
}

.direction-down {
    color: var(--accent-red);
    font-weight: 600;
}

.result-won {
    color: var(--accent-green);
    font-weight: 600;
}

.result-lost {
    color: var(--accent-red);
    font-weight: 600;
}

/* FAQs */
.faq-list {
    max-width: 800px;
    margin: 0 auto;
}

.faq-item {
    background-color: var(--bg-card);
    border: 1px solid var(--border-color);
    border-radius: 12px;
    margin-bottom: 1rem;
    overflow: hidden;
}

.faq-question {
    width: 100%;
    padding: 1.5rem;
    background: none;
    border: none;
    color: var(--text-primary);
    font-size: 1.1rem;
    font-weight: 600;
    text-align: left;
    cursor: pointer;
    display: flex;
    justify-content: space-between;
    align-items: center;
    transition: background-color 0.3s;
}

.faq-question:hover {
    background-color: var(--bg-hover);
}

.faq-icon {
    font-size: 1.5rem;
    color: var(--accent-green);
    transition: transform 0.3s;
}

.faq-item.active .faq-icon {
    transform: rotate(45deg);
}

.faq-answer {
    max-height: 0;
    overflow: hidden;
    transition: max-height 0.3s ease-out;
}

.faq-item.active .faq-answer {
    max-height: 200px;
}

.faq-answer p {
    padding: 0 1.5rem 1.5rem;
    color: var(--text-secondary);
    line-height: 1.6;
}

/* Contact Form */
.contact-container {
    max-width: 600px;
    margin: 0 auto;
}

.contact-form {
    background-color: var(--bg-card);
    padding: 2rem;
    border-radius: 12px;
    border: 1px solid var(--border-color);
}

.form-group {
    margin-bottom: 1.5rem;
}

.form-group label {
    display: block;
    margin-bottom: 0.5rem;
    color: var(--text-secondary);
    font-weight: 500;
}

textarea.input-field {
    resize: vertical;
    min-height: 120px;
}

/* Footer */
.footer {
    background-color: var(--bg-secondary);
    padding: 3rem 2rem;
    text-align: center;
    border-top: 1px solid var(--border-color);
}

.footer-text {
    font-size: 1.1rem;
    margin-bottom: 1rem;
    color: var(--text-primary);
}

.risk-warning {
    color: var(--accent-red);
    font-size: 0.875rem;
    max-width: 600px;
    margin: 0 auto 1rem;
    font-weight: 500;
}

.copyright {
    color: var(--text-secondary);
    font-size: 0.875rem;
}

/* Animations */
@keyframes pulse {
    0%, 100% { opacity: 1; }
    50% { opacity: 0.5; }
}

.pulse {
    animation: pulse 2s cubic-bezier(0.4, 0, 0.6, 1) infinite;
}

/* Mobile Responsive */
@media (max-width: 768px) {
    .nav-menu {
        position: fixed;
        left: -100%;
        top: 70px;
        flex-direction: column;
        background-color: var(--bg-secondary);
        width: 100%;
        text-align: center;
        transition: 0.3s;
        padding: 2rem 0;
        border-bottom: 1px solid var(--border-color);
    }

    .nav-menu.active {
        left: 0;
    }

    .mobile-menu-toggle {
        display: flex;
    }

    .hero h1 {
        font-size: 2.5rem;
    }

    .subtitle {
        font-size: 1rem;
    }

    .section-title {
        font-size: 2rem;
    }

    .stats-bar {
        grid-template-columns: repeat(2, 1fr);
    }

    #priceChart {
        height: 300px;
    }

    .trades-table {
        font-size: 0.75rem;
    }

    .trades-table th,
    .trades-table td {
        padding: 0.75rem 0.5rem;
    }
}

/* Scrollbar Styling */
::-webkit-scrollbar {
    width: 8px;
    height: 8px;
}

::-webkit-scrollbar-track {
    background: var(--bg-primary);
}

::-webkit-scrollbar-thumb {
    background: var(--bg-hover);
    border-radius: 4px;
}

::-webkit-scrollbar-thumb:hover {
    background: var(--border-color);
}