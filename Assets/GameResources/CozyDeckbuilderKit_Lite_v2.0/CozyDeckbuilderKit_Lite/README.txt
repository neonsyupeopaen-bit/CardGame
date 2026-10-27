COZY DECKBUILDER KIT LITE  (v2.0)
============================================
49 pixel art assets for card battlers and roguelike deckbuilders.
Free sample of Cozy Deckbuilder Kit (359 assets).
- Card frames (5 types x 3 rarities + card back): 3
- 9-slice frames: 2
- Cost gems: 2
- Type & rarity badges: 2
- Card art 32x32: 6
- Intent & status icons: 6
- Energy orbs & counter: 2
- Deck, draw, discard & exhaust piles: 2
- Relics: 3
- Map nodes: 4
- Enemy sprites 32x32: 1
- Large card frames 72x104 (5 types x 3 rarities + land, event, item): 1
- Text heavy compact frames 48x64: 1
- Card backs (8 designs x 2 sizes + blank backs): 2
- Stat badges (attack, health, armour, shield): 2
- Counters with blank number plates: 1
- Small numbers 3x5: 3
- Keyword chips (9-slice pills): 1
- Keyword icons 8x8: 2
- Upgrade markers: 1
- Tokens: 1
- Status stack number plates: 1

SIZES
- Compact card frames, text heavy compact frames and compact card backs: 48x64
- Large card frames and large card backs: 72x104
- Card art and enemy sprites: 32x32 (show card art at 2x in large frames, cropped to art_rect)
- Icons, cost gems, badges, relics, map nodes, energy orbs, stat badges, counters, tokens: 16x16
- Keyword icons: 10x10, keyword chips: 32x11, rarity gems and set symbols: 8x8 to 9x9
- Upgrade markers: plus 12x10, arrow 12x10, plus plus 13x7, big star 11x11, stars 1/2/3: 7x6, 13x6, 19x6
- Small numbers: 5x7, status stack plates: 9x9
- Piles, energy counter, shuffle and hit pop frames: 24x24
- Card glow frames: 52x68 (2px larger than a compact card on each side, draw centred behind it)
- Damage digits: 9x11

CONTENTS
- 1x/, 2x/, 3x/<category>/   every asset at 1x, 2x and 3x (nearest-neighbour, pixel exact)
- spritesheets/   one sheet per category plus all_<scale>x.png, at each scale
- index.json / index.csv   name, category, scale, sheet, x, y, w, h and the file path of every asset,
                  plus metadata: nine_slice margins (9-slice frames), art_rect / cost_center / title_rect /
                  text_rect (card frames), frame / frames / fps (animations). Values are given per scale.
- previews/       labeled previews per category
- animations_preview/   GIF previews of the card glow, shuffle and hit pop animations
- palette.png / palette.hex   the 28-colour palette shared with Cozy Life Icons, Cozy Spooky Icons,
  Cozy Pixel VFX and Cozy UI Kit

HOW TO USE THE CARD FRAMES
Every card frame has a transparent art window. Draw the art first at art_rect, then draw the frame on
top so it masks the window corners. All rectangles are in index.json per scale as [x, y, w, h].
- cost_center: centre of the 16x16 cost gem (top-left at 0,0 at 1x), the gem sits exactly on the socket.
- title_rect: card name. Large frames fit about 12 characters of Cozy Pixel Tiny (or about 8 of Regular).
- type_rect: type line on large frames (for example "Spell Attack"), about 12 characters of Tiny.
- set_slot_rect: blank set or expansion symbol slot on large frames (use a set_ symbol or your own 7x7).
- text_rect: rules text. Large frames fit 5 lines of Tiny (6px line pitch), text heavy compact frames 4.
- footer_rect: large frames only, a short line such as a collector number.

STRETCHING (9-SLICE)
Large frames and text heavy compact frames carry nine_slice margins with mode "tile": repeat the centre
band (do not scale it) to make a card taller or wider. Only the rules text box grows in height, so the
title, art window, type line and gem stay crisp. text_rect_by_height lists the text rectangle for a few
example heights; for any other height add the extra height to text_rect h. Keyword chips use mode
"tile_x": stretch them horizontally only. QA checks that every tiled band repeats seamlessly.

MARKERS
Stat badges, counters and status stack plates are blank: draw a num_ digit (3x5) or a damage digit on
number_center. Stack plates go over the bottom right of a 16x16 status icon (anchor_on_16px_icon).

ANIMATIONS
card_glow, shuffle and hit_pop each have 4 frames (<name>_1 to <name>_4) kept at a fixed canvas, so they
stay aligned when played in order. Suggested speed: 8 fps (hit_pop 12 fps).

HOW THEY WERE MADE
Every asset was drawn in code (Python + Pillow): hand-written colour grids and small shape helpers placed
pixel by pixel. No AI image generation was used.

LICENSE (summary, see LICENSE.txt)
Use in personal and commercial projects (games, apps, videos, prototypes), modified or not;
no attribution required (credit appreciated).
Do NOT resell, redistribute or re-upload the assets themselves (as is or lightly modified),
standalone or inside another asset pack, and do not use them to train AI / machine-learning models.
