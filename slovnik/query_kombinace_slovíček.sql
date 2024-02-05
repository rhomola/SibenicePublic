WITH combined AS (
  (SELECT anglicke_slovicko AS slovicko FROM slovnik_pro_sibenici WHERE length(anglicke_slovicko) > 5)
  UNION
  (SELECT ceske_slovicko AS slovicko FROM slovnik_pro_sibenici WHERE length(ceske_slovicko) > 5)
)

SELECT slovicko FROM combined
ORDER BY RANDOM()
LIMIT 100;