WITH TblParcelasEmAtraso AS
(
	SELECT 		f.IdCliente,
				p.IdFinanciamento,
				p.DataVencimento
	FROM 		Parcelas p 
	INNER JOIN	Financiamentos f ON f.Id = p.IdFinanciamento 
	WHERE 		p.DataVencimento < GETDATE() 
	AND 		p.DataPagamento IS NULL
	AND			DATEDIFF(DAY, p.DataVencimento, GETDATE()) > 5	
	GROUP BY	p.IdFinanciamento, 
				f.IdCliente,
				p.DataVencimento				
)

SELECT DISTINCT TOP 4 
				t.IdCliente,
				c.Nome,
				c.UF
FROM			TblParcelasEmAtraso t
INNER JOIN		Clientes c on c.Id = t.IdCliente
GROUP BY 		t.IdCliente,
				c.Nome,
				c.UF 
 		