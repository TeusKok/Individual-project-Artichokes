export type Card = {
    cardName: string;
    cardDescription: string;
}

export type Player = {
    name: string;
    hasTurn: Boolean;
    harvestedCard: Boolean;
    hand: Hand;
    drawPile: DrawPile;
    discardPile: DiscardPile;
}

export type Hand = {
    cards: Card[];
}

export type DrawPile = {
    numberOfCards: number;
}

export type DiscardPile = {
    topCard: Card;
}

export type ArtichokesGame = {
    players: Player[];
    gardenStock: GardenStock;
    gardenSupply: GardenSupply;
    
}

export type GardenStock = {
    numberOfCards: number;
}

export type GardenSupply = {
    cards: Card[];
    cardHarvestingAllowed: boolean;
}
