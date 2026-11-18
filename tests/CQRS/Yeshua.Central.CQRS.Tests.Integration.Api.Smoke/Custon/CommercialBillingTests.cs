using Dominio.Commercial.Central;

namespace Central.Commercial.Tests;

public sealed class CommercialBillingTests
{
    [Fact]
    public void Six_month_purchase_uses_calendar_months()
    {
        var now = new DateTime(2026, 11, 17, 14, 30, 0, DateTimeKind.Utc);
        Assert.Equal(now.AddMonths(6), CommercialOffers.ExtendPeriod(null, now, 6));
    }

    [Fact]
    public void Renewal_preserves_remaining_time_and_expired_access_restarts_now()
    {
        var now = new DateTime(2028, 1, 31, 12, 0, 0, DateTimeKind.Utc);
        Assert.Equal(new DateTime(2028, 2, 29, 12, 0, 0, DateTimeKind.Utc), CommercialOffers.ExtendPeriod(now.AddDays(-1), now, 1));
        Assert.Equal(now.AddMonths(3), CommercialOffers.ExtendPeriod(now.AddMonths(2), now, 1));
        Assert.Throws<ArgumentOutOfRangeException>(() => CommercialOffers.ExtendPeriod(null, now, 0));
    }

    [Fact]
    public void Transcription_has_period_and_prepaid_offers_independent_of_clinic_access()
    {
        var transcription = CommercialOffers.All.Where(offer => offer.Resource == "clinica.transcription").ToArray();
        Assert.Equal(2, transcription.Length);
        Assert.Contains(transcription, offer => offer.Model == "period" && offer.Months == 1);
        Assert.Contains(transcription, offer => offer.Model == "credits" && offer.Units > 0);
        Assert.All(transcription, offer => Assert.False(offer.GrantsApplicationAccess));
        Assert.True(Assert.Single(CommercialOffers.All.Where(offer => offer.Resource == "clinica.access")).GrantsApplicationAccess);
    }
}
