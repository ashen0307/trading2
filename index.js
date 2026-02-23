// script.js

// Application State
const state = {
    balance: 10000,
    openTrades: [],
    tradeHistory: [],
    stats: {
        won: 0,
        lost: 0
    },
    currentAsset: 'EUR/USD',
    currentPrice: 1.0845,
    basePrice: 1.0845,
    selectedTimeframe: 30,
    tradeAmount: 100,
    priceHistory: [],
    maxHistoryPoints: 100,
    lastPriceUpdate: Date.now()
};

// DOM Elements
const elements = {
    balanceDisplay: document.getElementById('balanceDisplay'),
    openTradesCount: document.getElementById('openTradesCount'),
    wonCount: document.getElementById('wonCount'),
    lostCount: document.getElementById('lostCount'),
    currentAsset: document.getElementById('currentAsset'),
    currentPrice: document.getElementById('currentPrice'),
    priceChange: document.getElementById('priceChange'),
    assetSelect: document.getElementById('assetSelect'),
    tradeAmount: document.getElementById('tradeAmount'),
    payoutDisplay: document.getElementById('payoutDisplay'),
    upBtn: document.getElementById('upBtn'),
    downBtn: document.getElementById('downBtn'),
    openTradesBody: document.getElementById('openTradesBody'),
    historyBody: document.getElementById('historyBody'),
    canvas: document.getElementById('priceChart'),
    mobileMenuToggle: document.getElementById('mobileMenuToggle'),
    navMenu: document.getElementById('navMenu'),
    contactForm: document.getElementById('contactForm')
};

// Canvas Context
const ctx = elements.canvas.getContext('2d');

// Initialize Application
function init() {
    initializePriceHistory();
    setupEventListeners();
    startPriceSimulation();
    renderChart();
    updateStats();
    
    // Handle canvas resize
    window.addEventListener('resize', handleResize);
    handleResize();
}

// Initialize Price History with random walk
function initializePriceHistory() {
    let price = state.basePrice;
    const now = Date.now();
    
    for (let i = 0; i < state.maxHistoryPoints; i++) {
        state.priceHistory.push({
            price: price,
            time: now - (state.maxHistoryPoints - i) * 1000
        });
        
        // Random walk
        const change = (Math.random() - 0.5) * (price * 0.002);
        price += change;
    }
    
    state.currentPrice = price;
}

// Setup Event Listeners
function setupEventListeners() {
    // Mobile menu toggle
    elements.mobileMenuToggle.addEventListener('click', () => {
        elements.navMenu.classList.toggle('active');
    });

    // Close mobile menu when clicking a link
    document.querySelectorAll('.nav-link').forEach(link => {
        link.addEventListener('click', () => {
            elements.navMenu.classList.remove('active');
        });
    });

    // Asset selection
    elements.assetSelect.addEventListener('change', (e) => {
        const option = e.target.selectedOptions[0];
        state.currentAsset = e.target.value;
        state.basePrice = parseFloat(option.dataset.base);
        state.currentPrice = state.basePrice;
        
        // Reset price history for new asset
        state.priceHistory = [];
        initializePriceHistory();
        
        elements.currentAsset.textContent = state.currentAsset;
        updatePriceDisplay();
    });

    // Trade amount input
    elements.tradeAmount.addEventListener('input', (e) => {
        state.tradeAmount = parseInt(e.target.value) || 0;
        updatePayoutDisplay();
    });

    // Timeframe selection
    document.querySelectorAll('.tf-select').forEach(btn => {
        btn.addEventListener('click', (e) => {
            document.querySelectorAll('.tf-select').forEach(b => b.classList.remove('active'));
            e.target.classList.add('active');
            state.selectedTimeframe = parseInt(e.target.dataset.time);
        });
    });

    // Chart timeframe buttons
    document.querySelectorAll('.tf-btn').forEach(btn => {
        btn.addEventListener('click', (e) => {
            document.querySelectorAll('.tf-btn').forEach(b => b.classList.remove('active'));
            e.target.classList.add('active');
        });
    });

    // Trade buttons
    elements.upBtn.addEventListener('click', () => createTrade('UP'));
    elements.downBtn.addEventListener('click', () => createTrade('DOWN'));

    // FAQ Accordion
    document.querySelectorAll('.faq-question').forEach(question => {
        question.addEventListener('click', () => {
            const item = question.parentElement;
            const isActive = item.classList.contains('active');
            
            // Close all
            document.querySelectorAll('.faq-item').forEach(i => i.classList.remove('active'));
            
            // Open clicked if wasn't active
            if (!isActive) {
                item.classList.add('active');
            }
        });
    });

    // Contact form
    elements.contactForm.addEventListener('submit', (e) => {
        e.preventDefault();
        alert('Message sent (demo)! We will get back to you soon.');
        elements.contactForm.reset();
    });
}

// Price Simulation
function startPriceSimulation() {
    setInterval(() => {
        updatePrice();
        checkExpiredTrades();
        renderChart();
        updateOpenTradesDisplay();
    }, 1000);
}

function updatePrice() {
    const volatility = state.currentPrice * 0.001; // 0.1% volatility
    const change = (Math.random() - 0.5) * volatility;
    
    state.currentPrice += change;
    
    // Add to history
    state.priceHistory.push({
        price: state.currentPrice,
        time: Date.now()
    });
    
    // Keep only max points
    if (state.priceHistory.length > state.maxHistoryPoints) {
        state.priceHistory.shift();
    }
    
    updatePriceDisplay();
}

function updatePriceDisplay() {
    const price = state.currentPrice.toFixed(state.currentPrice > 100 ? 2 : 4);
    elements.currentPrice.textContent = price;
    
    // Calculate change from base
    const change = ((state.currentPrice - state.basePrice) / state.basePrice) * 100;
    const changeStr = (change >= 0 ? '+' : '') + change.toFixed(2) + '%';
    
    elements.priceChange.textContent = changeStr;
    elements.priceChange.className = 'price-change ' + (change >= 0 ? 'positive' : 'negative');
}

function updatePayoutDisplay() {
    const payout = Math.floor(state.tradeAmount * 1.8);
    elements.payoutDisplay.textContent = '$' + payout;
}

// Trade Creation
function createTrade(direction) {
    if (state.tradeAmount > state.balance) {
        alert('Insufficient balance!');
        return;
    }
    
    if (state.tradeAmount < 10) {
        alert('Minimum trade amount is $10');
        return;
    }
    
    const trade = {
        id: Date.now(),
        asset: state.currentAsset,
        direction: direction,
        amount: state.tradeAmount,
        entryPrice: state.currentPrice,
        expiryTime: Date.now() + (state.selectedTimeframe * 1000),
        status: 'OPEN',
        createdAt: new Date().toLocaleTimeString()
    };
    
    state.openTrades.push(trade);
    state.balance -= state.tradeAmount;
    
    updateStats();
    renderOpenTrades();
    
    // Visual feedback
    const btn = direction === 'UP' ? elements.upBtn : elements.downBtn;
    btn.style.transform = 'scale(0.95)';
    setTimeout(() => btn.style.transform = '', 150);
}

// Check and close expired trades
function checkExpiredTrades() {
    const now = Date.now();
    const expiredTrades = state.openTrades.filter(trade => trade.expiryTime <= now);
    
    expiredTrades.forEach(trade => {
        closeTrade(trade);
    });
    
    if (expiredTrades.length > 0) {
        state.openTrades = state.openTrades.filter(trade => trade.expiryTime > now);
        updateStats();
        renderOpenTrades();
        renderHistory();
    }
}

function closeTrade(trade) {
    const exitPrice = state.currentPrice;
    const priceDiff = exitPrice - trade.entryPrice;
    
    let won = false;
    
    if (trade.direction === 'UP' && priceDiff > 0) {
        won = true;
    } else if (trade.direction === 'DOWN' && priceDiff < 0) {
        won = true;
    }
    
    // 50/50 chance if price didn't move (rare) or for randomness
    if (priceDiff === 0) {
        won = Math.random() > 0.5;
    }
    
    const profit = won ? Math.floor(trade.amount * 0.8) : -trade.amount;
    
    if (won) {
        state.balance += trade.amount + (trade.amount * 0.8);
        state.stats.won++;
    } else {
        state.stats.lost++;
    }
    
    const closedTrade = {
        ...trade,
        exitPrice: exitPrice,
        result: won ? 'WON' : 'LOST',
        profit: profit,
        closedAt: new Date().toLocaleTimeString()
    };
    
    state.tradeHistory.unshift(closedTrade);
}

// Rendering Functions
function updateStats() {
    elements.balanceDisplay.textContent = '$' + state.balance.toFixed(2);
    elements.openTradesCount.textContent = state.openTrades.length;
    elements.wonCount.textContent = state.stats.won;
    elements.lostCount.textContent = state.stats.lost;
}

function renderOpenTrades() {
    if (state.openTrades.length === 0) {
        elements.openTradesBody.innerHTML = '<tr class="empty-row"><td colspan="7">No open trades. Start trading now!</td></tr>';
        return;
    }
    
    elements.openTradesBody.innerHTML = state.openTrades.map(trade => {
        const timeLeft = Math.max(0, Math.ceil((trade.expiryTime - Date.now()) / 1000));
        const currentDiff = ((state.currentPrice - trade.entryPrice) / trade.entryPrice) * 100;
        const isWinning = (trade.direction === 'UP' && currentDiff > 0) || (trade.direction === 'DOWN' && currentDiff < 0);
        
        return `
            <tr>
                <td>${trade.asset}</td>
                <td class="${trade.direction === 'UP' ? 'direction-up' : 'direction-down'}">${trade.direction}</td>
                <td>$${trade.amount}</td>
                <td>${trade.entryPrice.toFixed(trade.entryPrice > 100 ? 2 : 4)}</td>
                <td class="${isWinning ? 'direction-up' : 'direction-down'}">${state.currentPrice.toFixed(state.currentPrice > 100 ? 2 : 4)}</td>
                <td>${timeLeft}s</td>
                <td><span class="pulse">●</span> Open</td>
            </tr>
        `;
    }).join('');
}

function updateOpenTradesDisplay() {
    if (state.openTrades.length > 0) {
        renderOpenTrades();
    }
}

function renderHistory() {
    if (state.tradeHistory.length === 0) {
        elements.historyBody.innerHTML = '<tr class="empty-row"><td colspan="8">No trade history yet.</td></tr>';
        return;
    }
    
    elements.historyBody.innerHTML = state.tradeHistory.map(trade => `
        <tr>
            <td>${trade.closedAt}</td>
            <td>${trade.asset}</td>
            <td class="${trade.direction === 'UP' ? 'direction-up' : 'direction-down'}">${trade.direction}</td>
            <td>$${trade.amount}</td>
            <td>${trade.entryPrice.toFixed(trade.entryPrice > 100 ? 2 : 4)}</td>
            <td>${trade.exitPrice.toFixed(trade.exitPrice > 100 ? 2 : 4)}</td>
            <td class="${trade.result === 'WON' ? 'result-won' : 'result-lost'}">${trade.result}</td>
            <td class="${trade.profit > 0 ? 'result-won' : 'result-lost'}">${trade.profit > 0 ? '+' : ''}$${trade.profit}</td>
        </tr>
    `).join('');
}

// Chart Rendering
function renderChart() {
    const canvas = elements.canvas;
    const width = canvas.width;
    const height = canvas.height;
    
    // Clear canvas
    ctx.fillStyle = '#1a1a1a';
    ctx.fillRect(0, 0, width, height);
    
    if (state.priceHistory.length < 2) return;
    
    // Calculate min/max for scaling
    const prices = state.priceHistory.map(p => p.price);
    const minPrice = Math.min(...prices) * 0.999;
    const maxPrice = Math.max(...prices) * 1.001;
    const priceRange = maxPrice - minPrice;
    
    // Draw grid
    ctx.strokeStyle = '#2a2a2a';
    ctx.lineWidth = 1;
    
    // Horizontal grid lines
    for (let i = 0; i <= 5; i++) {
        const y = (height / 5) * i;
        ctx.beginPath();
        ctx.moveTo(0, y);
        ctx.lineTo(width, y);
        ctx.stroke();
        
        // Price labels
        const price = maxPrice - (priceRange * (i / 5));
        ctx.fillStyle = '#666';
        ctx.font = '11px sans-serif';
        ctx.fillText(price.toFixed(price > 100 ? 2 : 4), width - 60, y + 12);
    }
    
    // Draw price line
    ctx.strokeStyle = state.priceHistory[state.priceHistory.length - 1].price >= state.priceHistory[0].price ? '#00c853' : '#ff1744';
    ctx.lineWidth = 2;
    ctx.beginPath();
    
    state.priceHistory.forEach((point, index) => {
        const x = (index / (state.maxHistoryPoints - 1)) * width;
        const y = height - ((point.price - minPrice) / priceRange) * height;
        
        if (index === 0) {
            ctx.moveTo(x, y);
        } else {
            ctx.lineTo(x, y);
        }
    });
    
    ctx.stroke();
    
    // Draw gradient fill under line
    ctx.lineTo(width, height);
    ctx.lineTo(0, height);
    ctx.closePath();
    
    const gradient = ctx.createLinearGradient(0, 0, 0, height);
    const isUp = state.priceHistory[state.priceHistory.length - 1].price >= state.priceHistory[0].price;
    gradient.addColorStop(0, isUp ? 'rgba(0, 200, 83, 0.2)' : 'rgba(255, 23, 68, 0.2)');
    gradient.addColorStop(1, 'rgba(0, 0, 0, 0)');
    ctx.fillStyle = gradient;
    ctx.fill();
    
    // Draw current price dot
    const lastPoint = state.priceHistory[state.priceHistory.length - 1];
    const lastX = width;
    const lastY = height - ((lastPoint.price - minPrice) / priceRange) * height;
    
    ctx.fillStyle = isUp ? '#00c853' : '#ff1744';
    ctx.beginPath();
    ctx.arc(lastX - 5, lastY, 4, 0, Math.PI * 2);
    ctx.fill();
    
    // Draw entry price lines for open trades
    state.openTrades.forEach(trade => {
        const entryY = height - ((trade.entryPrice - minPrice) / priceRange) * height;
        
        ctx.strokeStyle = trade.direction === 'UP' ? 'rgba(0, 200, 83, 0.5)' : 'rgba(255, 23, 68, 0.5)';
        ctx.setLineDash([5, 5]);
        ctx.beginPath();
        ctx.moveTo(0, entryY);
        ctx.lineTo(width, entryY);
        ctx.stroke();
        ctx.setLineDash([]);
        
        // Label
        ctx.fillStyle = trade.direction === 'UP' ? '#00c853' : '#ff1744';
        ctx.font = '10px sans-serif';
        ctx.fillText(`Entry ${trade.direction}`, 10, entryY - 2);
    });
}

function handleResize() {
    const container = elements.canvas.parentElement;
    const dpr = window.devicePixelRatio || 1;
    const rect = container.getBoundingClientRect();
    
    elements.canvas.width = rect.width * dpr;
    elements.canvas.height = 400 * dpr;
    elements.canvas.style.width = rect.width + 'px';
    elements.canvas.style.height = '400px';
    
    ctx.scale(dpr, dpr);
    renderChart();
}

// Start the application
document.addEventListener('DOMContentLoaded', init);