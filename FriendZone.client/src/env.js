export const dev = window.location.origin.includes('localhost')
export const baseURL = dev ? 'https://localhost:5001' : ''
export const useSockets = false
export const domain = 'dev-3m-y0xxd.us.auth0.com'
export const audience = 'https://DomDev.com'
export const clientId = 'G4ZPiDNVdwquzBEPf1t4fIg2bBm6ucuM'