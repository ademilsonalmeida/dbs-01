WITH TblPercentualPago AS
(
	SELECT 	IdFinanciamento,			
			TotalParcelas,
			TotalParcelasPagas,
			(CAST(TotalParcelasPagas AS DECIMAL(15,2)) / NULLIF(CAST(TotalParcelas AS DECIMAL(15,2)),0) * 100) AS PercentualPago
	FROM (
			SELECT		p.IdFinanciamento,
						(SELECT COUNT(*)
						FROM	Parcelas p3
						WHERE	p3.IdFinanciamento = p.IdFinanciamento) AS TotalParcelas,
						(SELECT	COUNT(*) 
						FROM 	Parcelas p2
						WHERE	p2.IdFinanciamento = p.IdFinanciamento
						AND		p2.DataPagamento IS NOT NULL) AS TotalParcelasPagas
			FROM 		Parcelas p
			WHERE		p.DataPagamento IS NOT NULL
			GROUP BY	p.IdFinanciamento
	) AS Tbl_TotalParcelas
)

SELECT 		c.Id,
			c.Nome,
			t.PercentualPago
FROM 		TblPercentualPago t
INNER JOIN 	Financiamentos f ON f.Id = t.IdFinanciamento
INNER JOIN	Clientes c ON c.Id = f.IdCliente 
WHERE 		PercentualPago > 60
AND 		c.UF = 'SP'